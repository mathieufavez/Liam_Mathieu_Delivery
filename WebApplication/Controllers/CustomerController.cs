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
    public class CustomerController : Controller
    {
        private ICustomerManager CustomerManager { get; }

        public CustomerController(ICustomerManager customerManager)
        {
            CustomerManager = customerManager;
        }

        [HttpGet]
        public IActionResult Connexion()
        {
            return View();
        }

       /* [HttpPost]
        public IActionResult Index()
        {
            bool isValid = LoginManager.IsUserValid(l);
            if (isValid)
            {
                HttpContext.Session.SetString("Username", l.Username);
                return RedirectToAction("GetHotels", "Hotel", new { isValid = isValid, user = "Antoine" });
            }
            else
            {
                return View();
            }
        }*/

    }
}