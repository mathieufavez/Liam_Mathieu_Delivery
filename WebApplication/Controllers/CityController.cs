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
    public class CityController : Controller
    {

        private ICityManager CityManager { get; }

        public CityController(ICityManager cityManager)
        {
            CityManager = cityManager;
        }

        // GET: AllCities
        public ActionResult ListeCities()
        {
            var cities = CityManager.GetAllCities();
            return View(cities);
        }
    }
}