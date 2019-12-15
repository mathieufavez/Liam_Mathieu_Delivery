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
    public class DishController : Controller
    {
        private IDishManager DishManager { get; }

        public DishController(IDishManager dishManager)
        {
            DishManager = dishManager;
        }
        
        //Retourne la vue des plats pour un restaurant choisi
        public ActionResult ListeDishes()
        {
            int idRestaurant = HttpContext.Session.GetInt32("IdRestaurant").GetValueOrDefault();
            var dishes = DishManager.GetAllDishes(idRestaurant);
            return View(dishes);
        }

        //Lorsque le client choisi son plat, le renvoie sur la page pour choisir la quantité sous le controlleur Order_Dish
        public ActionResult Choix(int id, int price) 
        {
            HttpContext.Session.SetInt32("DishPrice", price);
            HttpContext.Session.SetInt32("IdDish",id);
            return RedirectToAction("GetQuantity", "Order_Dish");
        }

        
    }
}