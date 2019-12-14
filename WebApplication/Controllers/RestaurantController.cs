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
        private ICityManager CityManager { get; }

        public RestaurantController(IRestaurantManager restaurantManager, ICityManager cityManager)
        {
            RestaurantManager = restaurantManager;
            CityManager = cityManager;
        }


        // Voir tous les restaurants avec nom de la ville à la place de idCity
        public ActionResult ListeRestaurant()
        {
            List<DTO.Restaurant> listeRestau = RestaurantManager.GetAllRestaurants();
            List<RestaurantCityViewModel> restaurantCity = new List<RestaurantCityViewModel>();

            foreach(DTO.Restaurant r in listeRestau) {
                RestaurantCityViewModel restaurantCityViewModel = new RestaurantCityViewModel();
                restaurantCityViewModel.Restaurants = r;
                restaurantCityViewModel.Cities = CityManager.GetCity(r.FK_idCity);
                restaurantCity.Add(restaurantCityViewModel);
            }
            return View(restaurantCity);
           
        }

        //Select the restaurant we chose
        public ActionResult ListOrder(int id)
        {
            return RedirectToAction("ListOrder", "Order", new { id = id });
        }

        //Redirige vers le controller Order et la méthode CreateOrder
        //Garde en mémoire l'idRestaurant
        public ActionResult CreateOrder(int id)
        {

            HttpContext.Session.SetInt32("IdRestaurant",id);
            return RedirectToAction("CreateOrder", "Order");
        }
    }
}