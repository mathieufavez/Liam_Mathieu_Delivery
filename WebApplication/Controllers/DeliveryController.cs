using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DAL;
using BLL;
using DTO;

namespace WebApplication.Controllers
{
    public class DeliveryController : Controller
    {
        private IDeliveryManager DeliveryManager { get; }
        private IDeliverymanManager DeliverymanManager { get; }

        public DeliveryController(IDeliveryManager deliveryManager, IDeliverymanManager deliverymanManager)
        {
            DeliveryManager = deliveryManager;
            DeliverymanManager = deliverymanManager;
        }

        public ActionResult ListeDeliverys(int idDeliveryman) 
        {
            idDeliveryman = HttpContext.Session.GetInt32("IdDeliveryman").GetValueOrDefault();
            var deliverys = DeliveryManager.GetAllDelivery(idDeliveryman);
            return View(deliverys);
        }

        public ActionResult CreateDelivery()
        {
            int idOrder = HttpContext.Session.GetInt32("IdOrder").GetValueOrDefault();
            int idRestaurant = HttpContext.Session.GetInt32("IdRestaurant").GetValueOrDefault();
            int idDeliveryTime = HttpContext.Session.GetInt32("Id_Delivery_time").GetValueOrDefault();
            int idCity = HttpContext.Session.GetInt32("IdCity").GetValueOrDefault();
            
            Delivery newDelivery = new Delivery { FK_idOrder = idOrder, FK_idRestaurant = idRestaurant, FK_idDelivery_Time = idDeliveryTime, Status = "A livrer" };
            DeliveryManager.AddDelivery(newDelivery);

            int idRightDeliveryman = DeliverymanManager.GetRightDeliveryman(idRestaurant, idCity);
            
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

    }
}