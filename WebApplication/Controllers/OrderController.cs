using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DAL;
using BLL;
using DTO;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class OrderController : Controller
    {
        private IOrderManager OrderManager { get; }

        private ICustomerManager CustomerManager { get; }

        private ICityManager CityManager { get; }

        private IDelivery_TimeManager Delivery_TimeManager { get; }

        private IOrder_DishManager Order_DishManager { get; }

        private IRestaurantManager RestaurantManager { get; }
        private IDishManager DishManager { get; }
        private IDeliveryManager DeliveryManager { get; }


        public OrderController(IOrderManager orderManager, ICustomerManager customerManager, ICityManager cityManager, IDelivery_TimeManager delivery_TimeManager, IOrder_DishManager order_DishManager, IRestaurantManager restaurantManager, IDishManager dishManager, IDeliveryManager deliveryManager)
        {
            OrderManager = orderManager;
            CustomerManager = customerManager;
            CityManager = cityManager;
            Delivery_TimeManager = delivery_TimeManager;
            Order_DishManager = order_DishManager;
            RestaurantManager = restaurantManager;
            DishManager = dishManager;
            DeliveryManager = deliveryManager;
      
        }

        //Lorsque le client choisi un restaurant, l'ordre est directement crée et redirige ensuite vers la liste des plats du restaurant en question
        public ActionResult CreateOrder ()
        {
            int idCustomer = HttpContext.Session.GetInt32("IdCustomer").GetValueOrDefault();
            DTO.Order newOrder  = new DTO.Order { Status = "En cours", FK_idCustomer = idCustomer };
            OrderManager.AddOrder(newOrder);

            int idOrder = newOrder.IdOrder;
            HttpContext.Session.SetInt32("IdOrder", idOrder);
            return RedirectToAction("ListOrder_Dish", "Order_Dish");
        }

        //Lorsque le client est dans son HomeCustomer, il peut choisir d'afficher toutes les commandes qu'il a effectué. Utilise le modèle OrderDeliveryDelivery_TimeViewModel
        public ActionResult ShowOrder() 
        {
            int idCustomer = HttpContext.Session.GetInt32("IdCustomer").GetValueOrDefault();
            List<DTO.Order> listeOrder= OrderManager.GetAllOrdersForOneCustomer(idCustomer);

            List <OrderDeliveryDelivery_TimeViewModel> orderDeliverytime = new List<OrderDeliveryDelivery_TimeViewModel>();

            foreach (DTO.Order o in listeOrder) 
            {
                OrderDeliveryDelivery_TimeViewModel orderDeliveryDelivery_TimeViewModel = new OrderDeliveryDelivery_TimeViewModel();
                orderDeliveryDelivery_TimeViewModel.Orders = o;
                orderDeliveryDelivery_TimeViewModel.Delivery_Times = Delivery_TimeManager.GetDelivery_Time(o.FK_idDelivery_Time);
                orderDeliverytime.Add(orderDeliveryDelivery_TimeViewModel);
            }

            return View(orderDeliverytime);
        }

        //Lorsque le client voit tous les ordres qu'il a effectué et qu'il veut en annuler 1, il doit inscrire son code
        //Cette méthode reprend ce qu'il inscrit
        [HttpGet]
        public IActionResult CancelOrder(int id)
        {
            HttpContext.Session.SetInt32("IdAnnulation", id);
            int idCustomer = HttpContext.Session.GetInt32("IdCustomer").GetValueOrDefault();
            ViewBag.Message = CustomerManager.Code(idCustomer);
            return View();
        }

        //Méthode qui lit si le code inscrit par le client pour annuler sa commande correspond à son code dans la BD
        [HttpPost]
        public IActionResult CancelOrder(Customer customer)
        {
            int idCustomer = HttpContext.Session.GetInt32("IdCustomer").GetValueOrDefault();
            string code = CustomerManager.Code(idCustomer);
            //Si ca correspond, la commande et la livraison sont annulée
            if (customer.Code == code) 
            {
                int idAnnulation = HttpContext.Session.GetInt32("IdAnnulation").GetValueOrDefault();
                string status = "Annulé";
                OrderManager.UpdateOrder(idAnnulation, status);
                Delivery delivery = DeliveryManager.GetDelivery(idAnnulation);
                DeliveryManager.UpdateDeliveryStatus(delivery.IdDelivery, status);
                return RedirectToAction("ShowOrder", "Order");
            }

            //Si ca ne correspond pas, redirige sur la même vue
            else
            {

                return View();
            }
          
        }


        //Vue complexe utilisant le modèle OrderDetailsViewModel
        //Permet d'afficher le nom du restaurant de la commande, le numéro de la commande, les plats choisis (bug, 1 seul plat est affiché), 
        //la quantité par plats, le prix unitaire d'un plat, l'heure de livraison...
        public ActionResult OrderDetails() 
        {
            List<OrderDetailsViewModel> listeOrderDetails = new List<OrderDetailsViewModel>();
            OrderDetailsViewModel orderDetails = new OrderDetailsViewModel();

            int idCustomer = HttpContext.Session.GetInt32("IdCustomer").GetValueOrDefault();
            int idOrder = HttpContext.Session.GetInt32("IdOrder").GetValueOrDefault();
            int idRestaurant = HttpContext.Session.GetInt32("IdRestaurant").GetValueOrDefault();
            int idDeliveryTime = HttpContext.Session.GetInt32("Id_Delivery_time").GetValueOrDefault();
            OrderManager.UpdateOrderDeliveryTime(idOrder ,idDeliveryTime);

            List<DTO.Order_Dish> listeOrder_Dishes = Order_DishManager.GetAllOrder_Dish(idOrder);
            DTO.Customer customer = CustomerManager.GetCustomer(idCustomer);
            DTO.Order order = OrderManager.GetOrder(idOrder);
            DTO.Restaurant restaurant = RestaurantManager.GetRestaurant(idRestaurant);
            

            orderDetails.Customers = customer;
            orderDetails.Orders = order;
            orderDetails.Restaurants = restaurant;
            orderDetails.Cities = CityManager.GetCity(customer.FK_idCity);
            orderDetails.Delivery_Times = Delivery_TimeManager.GetDelivery_Time(idDeliveryTime);

            foreach (DTO.Order_Dish od in listeOrder_Dishes)
            {

                orderDetails.Order_Dishes = od;
                orderDetails.Dishes = DishManager.GetDish(od.FK_idDish);
            }

            listeOrderDetails.Add(orderDetails);
            return View(listeOrderDetails);

        }

        //Après avoir vu les détails de sa commande, le client choisit de valider
        //Redirige vers DeliveryControlleur pour créer la livraison
        public ActionResult Valider()
        {

            return RedirectToAction("CreateDelivery","Delivery");
        }

        //Après avoir vu les détails de sa commande, le client choisit de l'annuler
        //Change le statut de l'ordre en annulé et retourne la vue comme quoi ca a bien été annulé
        public ActionResult Annuler() 
        {
            int idOrder = HttpContext.Session.GetInt32("IdOrder").GetValueOrDefault();
            string newStatus = "Annulé";
            OrderManager.UpdateOrder(idOrder,newStatus);
            return View();
        }
    }
}