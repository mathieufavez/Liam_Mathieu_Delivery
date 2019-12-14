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
                return RedirectToAction("ListeRestaurant", "Restaurant", new { id = idCustomer });
            }

            else
            {

                return View( );
            }
        }

    }
}