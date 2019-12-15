using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        //Vue principale du site, permet de choisir si on est un livreur ou un client
        public IActionResult Index()
        {
            return View();
        }


        //Vue About du site, quelques infos sur l'entreprise
        public IActionResult About()
        {
            ViewData["Message"] = "Tout ce qu'il y a à savoir sur notre entreprise ! ";

            return View();
        }

        //Vue contact du site, avec addresse
        public IActionResult Contact()
        {
            ViewData["Message"] = "N'hésitez pas à nous contacter";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
