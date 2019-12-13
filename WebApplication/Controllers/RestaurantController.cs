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
        public ActionResult ListOrder(int id)
        {
            return RedirectToAction("ListOrder", "Order", new { id = id });
        }

        //Redirige vers le controller Order et la méthode CreateOrder
        public ActionResult CreateOrder(int id)
        {

            HttpContext.Session.SetInt32("IdRestaurant",id);
            return RedirectToAction("CreateOrder", "Order");
        }

   
    }
}