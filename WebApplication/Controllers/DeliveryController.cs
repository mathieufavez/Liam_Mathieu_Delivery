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

        public DeliveryController(IDeliveryManager deliveryManager)
        {
            DeliveryManager = deliveryManager;
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
            int idDeliveryTime = HttpContext.Session.GetInt32("IdDelivery_Time").GetValueOrDefault();
            Delivery newDelivery = new Delivery{ FK_idOrder=idOrder, FK_idRestaurant=idRestaurant, FK_idDelivery_Time=idDeliveryTime, Status="A livrer"};
            DeliveryManager.AddDelivery(newDelivery);
            return RedirectToAction("ShowOrder","Order");
        }

    }
}