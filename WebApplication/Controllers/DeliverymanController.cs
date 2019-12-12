using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DAL;
using BLL;

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
        public IActionResult Index(int id, string login)
        {
            string password = DeliverymanManager.GetPassword(id,login);
            if (password == DeliverymanManager.GetPassword(id, login))
            {
                HttpContext.Session.SetString("Login", login);
                return RedirectToAction("GetHotels", "Hotel", new {  user = login });
            }

            else
            {
                return View();
            }
        }

    }
}