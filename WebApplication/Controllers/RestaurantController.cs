using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class RestaurantController : Controller
    {

        private IRestaurantManager RestaurantManager { get; }

        public RestaurantController(IRestaurantManager restaurantManager)
        {
            RestaurantManager = restaurantManager;
        }

        // GET: AllRestaurants
        public ActionResult ListeRestaurant()
        {
            var restaurant = RestaurantManager.GetAllRestaurants();
            return View(restaurant);
        }

        //Select the restaurant we chose
        public ActionResult Select(int idRestaurant) 
        {

            HttpContext.Session.SetInt32("idRestaurant", idRestaurant);
            var restaurant = RestaurantManager.GetRestaurant(idRestaurant);
            return View(restaurant);
        }

        public ActionResult Continue() 
        {
            int idRestaurant= HttpContext.Session.GetInt32("idRestaurant").GetValueOrDefault();
            return RedirectToAction("ListeDishes", "Dish", new { id = idRestaurant });
        }
    }
}