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
    public class DeliverymanController : Controller
    {

        private IDeliverymanManager DeliverymanManager { get; }
      
        public DeliverymanController(IDeliverymanManager deliverymanManager)
        {
            DeliverymanManager = deliverymanManager;
        }


        [HttpGet]
        public IActionResult Connexion()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Connexion(Deliveryman deliveryman)
        {

            int idDeliveryman = DeliverymanManager.GetIdDeliveryman(deliveryman.Login);
            string password = DeliverymanManager.GetPassword(idDeliveryman, deliveryman.Login);
            if (deliveryman.Password == password)
            {
                HttpContext.Session.SetString("Login", deliveryman.Login);
                return RedirectToAction("ListeCities", "City", new { id = idDeliveryman });
            }

            else
            {
                return View();
            }
        }

    }
}