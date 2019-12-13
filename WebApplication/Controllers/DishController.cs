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
        
        // GET: AllDishes for a restaurant
        public ActionResult ListeDishes()
        {
            int idRestaurant = HttpContext.Session.GetInt32("IdRestaurant").GetValueOrDefault();
            var dishes = DishManager.GetAllDishes(idRestaurant);
            return View(dishes);
        }

        public ActionResult Choix(int id) 
        {
            HttpContext.Session.SetInt32("IdDish",id);
            return RedirectToAction("CreateOrder_Dish", "Order_Dish");
        }

        
    }
}