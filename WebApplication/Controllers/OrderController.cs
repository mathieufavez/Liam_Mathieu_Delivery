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



        public OrderController(IOrderManager orderManager, ICustomerManager customerManager, ICityManager cityManager, IDelivery_TimeManager delivery_TimeManager, IOrder_DishManager order_DishManager, IRestaurantManager restaurantManager)
        {
            OrderManager = orderManager;
            CustomerManager = customerManager;
            CityManager = cityManager;
            Delivery_TimeManager = delivery_TimeManager;
            Order_DishManager = order_DishManager;
            RestaurantManager = restaurantManager;
      
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
            var ordersForAClient= OrderManager.GetAllOrdersForOneCustomer(idCustomer);
            
            return View(ordersForAClient);

        }

        public ActionResult OrderDetails() 
        {

            List<OrderDetailsViewModel> listeOrderDetails = new List<OrderDetailsViewModel>();
            OrderDetailsViewModel orderDetails = new OrderDetailsViewModel();

            int idCustomer = HttpContext.Session.GetInt32("IdCustomer").GetValueOrDefault();
            int idOrder = HttpContext.Session.GetInt32("IdOrder").GetValueOrDefault();
            int idRestaurant = HttpContext.Session.GetInt32("IdRestaurant").GetValueOrDefault();
            int idDeliveryTime = HttpContext.Session.GetInt32("Id_Delivery_time").GetValueOrDefault();

            List<DTO.Order_Dish> listeOrder_Dishes = Order_DishManager.GetAllOrder_Dish(idOrder);
            DTO.Customer customer = CustomerManager.GetCustomer(idCustomer);
            DTO.Order order = OrderManager.GetOrder(idOrder);
            DTO.Restaurant restaurant = RestaurantManager.GetRestaurant(idRestaurant);



            orderDetails.Customers = customer;
            orderDetails.Orders = order;
            orderDetails.Restaurants = restaurant;
            orderDetails.Cities = CityManager.GetCity(customer.FK_idCity);
            orderDetails.Delivery_Times =Delivery_TimeManager.GetDelivery_Time(idDeliveryTime);

           
           
            
            /*foreach (DTO.Order_Dish od in listeOrder_Dishes)
            {
                orderDetails.Order_Dishes = od;
                orderDetails.Order_Dishes = Order_DishManager.GetOrder_Dish(od.FK_idOrder);
            }*/

            listeOrderDetails.Add(orderDetails);
            return View(listeOrderDetails);

        }
    }
}