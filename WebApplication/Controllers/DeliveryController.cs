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
    public class DeliveryController : Controller
    {
        private IDeliveryManager DeliveryManager { get; }
        private IDeliverymanManager DeliverymanManager { get; }
        private IOrderManager OrderManager { get; }
        private IRestaurantManager RestaurantManager { get; }
        private IDelivery_TimeManager Delivery_TimeManager { get; }
        private ICustomerManager CustomerManager { get; }
        private ICityManager CityManager { get; }

        public DeliveryController(IDeliveryManager deliveryManager, IDeliverymanManager deliverymanManager, IOrderManager orderManager, IRestaurantManager restaurantManager, IDelivery_TimeManager delivery_TimeManager, ICustomerManager customerManager, ICityManager cityManager)
        {
            DeliveryManager = deliveryManager;
            DeliverymanManager = deliverymanManager;
            OrderManager = orderManager;
            RestaurantManager = restaurantManager;
            Delivery_TimeManager = delivery_TimeManager;
            CustomerManager = customerManager;
            CityManager = cityManager;
        }

        public ActionResult ListeDeliverys(int idDeliveryman) 
        {
            List<DeliveryDetailsViewModel> listeDelivery = new List<DeliveryDetailsViewModel>();

            idDeliveryman = HttpContext.Session.GetInt32("IdDeliveryman").GetValueOrDefault();
            List<DTO.Delivery> listDeliverys = DeliveryManager.GetAllDelivery(idDeliveryman);

            foreach (DTO.Delivery d in listDeliverys)
            {
                DeliveryDetailsViewModel deliveryDetails = new DeliveryDetailsViewModel();
                deliveryDetails.Deliverys = d;
                deliveryDetails.Orders = OrderManager.GetOrder(d.FK_idOrder);
                deliveryDetails.Restaurants = RestaurantManager.GetRestaurant(d.FK_idRestaurant);
                deliveryDetails.Delivery_Times = Delivery_TimeManager.GetDelivery_Time(d.FK_idDelivery_Time);

                listeDelivery.Add(deliveryDetails);
            }

            return View(listeDelivery);
        }

        public ActionResult CreateDelivery()
        {
            int idOrder = HttpContext.Session.GetInt32("IdOrder").GetValueOrDefault();
            int idRestaurant = HttpContext.Session.GetInt32("IdRestaurant").GetValueOrDefault();
            int idDeliveryTime = HttpContext.Session.GetInt32("Id_Delivery_time").GetValueOrDefault();
            int idCity = HttpContext.Session.GetInt32("IdCity").GetValueOrDefault();
            
            Delivery newDelivery = new Delivery { FK_idOrder = idOrder, FK_idRestaurant = idRestaurant, FK_idDelivery_Time = idDeliveryTime, Status = "A livrer" };
            DeliveryManager.AddDelivery(newDelivery);

            int idRightDeliveryman = DeliverymanManager.GetRightDeliveryman(idCity);
            
            if (idRightDeliveryman == 0)
            {
                return RedirectToAction("NoDeliverymanAvailable", "Delivery");
            }
            else
            {
                DeliveryManager.UpdateDelivery( newDelivery.IdDelivery ,idRightDeliveryman);
                return RedirectToAction("DeliveryConfirmed", "Delivery");
            }
        }

        public ActionResult NoDeliverymanAvailable() 
        {

            return View();
        }

        public ActionResult DeliveryConfirmed()
        {
            return View();
        }

        public ActionResult DeliveryDone(int id, int idOrder) 
        {
            string status = "Effectué";
            DeliveryManager.UpdateDeliveryStatus(id, status);
            OrderManager.UpdateOrder(idOrder,"Livré");
            return RedirectToAction("ListeDeliverys", "Delivery");
        }
    }
}