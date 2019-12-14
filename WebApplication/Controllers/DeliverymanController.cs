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
    public class DeliverymanController : Controller
    {

        private IDeliverymanManager DeliverymanManager { get; }
        private ICityManager CityManager { get; }

        public DeliverymanController(IDeliverymanManager deliverymanManager, ICityManager cityManager)
        {
            DeliverymanManager = deliverymanManager;
            CityManager = cityManager;
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
                HttpContext.Session.SetInt32("IdDeliveryman", idDeliveryman);
                return RedirectToAction("HomeDeliveryman", "Deliveryman", new { id = idDeliveryman });
            }
            else
            {
                return View();
            }
        }

        public ActionResult HomeDeliveryman()
        {
            int idDeliveryman = HttpContext.Session.GetInt32("IdDeliveryman").GetValueOrDefault();
            Deliveryman deliveryman = DeliverymanManager.GetDeliveryman(idDeliveryman);
            List<DeliverymanCityViewModel> deliverymanCity = new List<DeliverymanCityViewModel>();

            DeliverymanCityViewModel deliverymanCityViewModel = new DeliverymanCityViewModel();
            deliverymanCityViewModel.Deliverymens = deliveryman;
            deliverymanCityViewModel.Cities = CityManager.GetCity(deliveryman.FK_idCity);
            deliverymanCity.Add(deliverymanCityViewModel);

            return View(deliverymanCity);
        }

        public ActionResult ShowDeliverys()
        {

            return RedirectToAction("ListeDeliverys", "Delivery");
        }

    }
}