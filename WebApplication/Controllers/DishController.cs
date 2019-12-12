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

        // GET: AllCities
        public ActionResult ListeCities()
        {
            int idRestaurant = 1;
            var dishes = DishManager.GetAllDishes(1);
            return View(dishes);
        }
    }
}