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

    }
}