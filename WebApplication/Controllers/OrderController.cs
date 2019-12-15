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

        public ActionResult CreateOrder (int id)
        {
            int idCustomer = HttpContext.Session.GetInt32("IdCustomer").GetValueOrDefault();
            DTO.Order newOrder  = new DTO.Order { Status = "En cours", FK_idCustomer = idCustomer };
            OrderManager.AddOrder(newOrder);

            int idOrder = newOrder.IdOrder;
            HttpContext.Session.SetInt32("IdOrder", idOrder);
            return RedirectToAction("ListOrder_Dish", "Order_Dish");
        }

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

        [HttpGet]
        public IActionResult CancelOrder(int id)
        {
            HttpContext.Session.SetInt32("IdAnnulation", id);
            int idCustomer = HttpContext.Session.GetInt32("IdCustomer").GetValueOrDefault();
            ViewBag.Message = CustomerManager.Code(idCustomer);
            return View();
        }

        [HttpPost]
        public IActionResult CancelOrder(Customer customer)
        {
            int idCustomer = HttpContext.Session.GetInt32("IdCustomer").GetValueOrDefault();
            string code = CustomerManager.Code(idCustomer);
            if (customer.Code == code) 
            {
                int idAnnulation = HttpContext.Session.GetInt32("IdAnnulation").GetValueOrDefault();
                string status = "Annulé";
                OrderManager.UpdateOrder(idAnnulation, status);
                Delivery delivery = DeliveryManager.GetDelivery(idAnnulation);
                DeliveryManager.UpdateDeliveryStatus(delivery.IdDelivery, status);
                return RedirectToAction("ShowOrder", "Order");
            }

            else
            {

                return View();
            }
          
        }

        public ActionResult OrderDetails() 
        {
            List<OrderDetailsViewModel> listeOrderDetails = new List<OrderDetailsViewModel>();
            OrderDetailsViewModel orderDetails = new OrderDetailsViewModel();

            int idCustomer = HttpContext.Session.GetInt32("IdCustomer").GetValueOrDefault();
            int idOrder = HttpContext.Session.GetInt32("IdOrder").GetValueOrDefault();
            int idRestaurant = HttpContext.Session.GetInt32("IdRestaurant").GetValueOrDefault();
            int idDeliveryTime = HttpContext.Session.GetInt32("Id_Delivery_time").GetValueOrDefault();
            OrderManager.UpdateOrderDeliveryTime(idOrder ,idDeliveryTime);
            int idDish = HttpContext.Session.GetInt32("IdDish").GetValueOrDefault();

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
                OrderDetailsViewModel orderDetailsViewModel = new OrderDetailsViewModel();
                orderDetailsViewModel.Order_Dishes = od;
                orderDetailsViewModel.Order_Dishes = Order_DishManager.GetOrder_Dish(od.FK_idOrder);
                orderDetailsViewModel.Dishes = DishManager.GetDish(od.FK_idDish);
                listeOrderDetails.Add(orderDetailsViewModel);
            }

            listeOrderDetails.Add(orderDetails);
            return View(listeOrderDetails);

        }

        public ActionResult Valider()
        {

            return RedirectToAction("CreateDelivery","Delivery");
        }
        public ActionResult Annuler() 
        {
            int idOrder = HttpContext.Session.GetInt32("IdOrder").GetValueOrDefault();
            string newStatus = "Annulé";
            OrderManager.UpdateOrder(idOrder,newStatus);
            return View();
        }
    }
}