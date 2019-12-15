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

        //Vue pour que le livreur insère son login et mot de passe
        [HttpGet]
        public IActionResult Connexion()
        {
            return View();
        }

        //Reprend les insertions du livreur et regarde si cela correspond à la BD
        [HttpPost]
        public IActionResult Connexion(Deliveryman deliveryman)
        {
            int idDeliveryman = DeliverymanManager.GetIdDeliveryman(deliveryman.Login);
            string password = DeliverymanManager.GetPassword(idDeliveryman, deliveryman.Login);
            //Si ca correspond, passe à la vue HomeDeliveryman
            if (deliveryman.Password == password)
            {
                HttpContext.Session.SetInt32("IdDeliveryman", idDeliveryman);
                return RedirectToAction("HomeDeliveryman", "Deliveryman", new { id = idDeliveryman });
            }
            //Si ca ne correspond pas, reste sur la connexion
            else
            {
                return View();
            }
        }

        //Accueil livreur, affiche son nom et son adresse via le Modele DeliverymanCityViewModel
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

        //Quand le livreur clique sur le bouton afficher les livraisons, il arrive ici qui renvoie sous DeliveryController pour la liste des livraisons
        public ActionResult ShowDeliverys()
        {

            return RedirectToAction("ListeDeliverys", "Delivery");
        }

    }
}