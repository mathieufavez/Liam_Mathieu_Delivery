using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DAL;
using BLL;
using DTO;

namespace WebApplication.Controllers
{
    public class CustomerController : Controller
    {


        //Test push
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

        [HttpPost]
        public IActionResult Connexion(Customer customer)
        {

            int idCustomer = CustomerManager.GetIdCustomer(customer.Login);
            string password = CustomerManager.GetPassword(idCustomer, customer.Login);
            if (customer.Password == password)
            {

                HttpContext.Session.SetInt32("IdCustomer", idCustomer);
                return RedirectToAction("HomeCustomer", "Customer");
            }

            else
            {

                return View();
            }
        }

        public ActionResult HomeCustomer() 
        {
            int idCustomer = HttpContext.Session.GetInt32("IdCustomer").GetValueOrDefault();
            var customer = CustomerManager.GetCustomer(idCustomer);
            return View(customer);
        }

        public ActionResult ShowRestaurant() 
        {
            return RedirectToAction("ListeRestaurant","Restaurant");
        }

    }
}