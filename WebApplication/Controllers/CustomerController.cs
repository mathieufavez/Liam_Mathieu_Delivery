using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DAL;
using BLL;
using DTO;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class CustomerController : Controller
    {


        //Test push
        private ICustomerManager CustomerManager { get; }
        private ICityManager CityManager { get; }

        public CustomerController(ICustomerManager customerManager, ICityManager cityManager)
        {
            CustomerManager = customerManager;
            CityManager = cityManager;
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
            Customer customer = CustomerManager.GetCustomer(idCustomer);
            List<CustomerCityViewModel> customerCity = new List<CustomerCityViewModel>();
          
                CustomerCityViewModel customerCityViewModel = new CustomerCityViewModel();
                customerCityViewModel.Customers = customer;
                customerCityViewModel.Cities = CityManager.GetCity(customer.FK_idCity);
                customerCity.Add(customerCityViewModel);
            
            return View(customerCity);
        }

        public ActionResult ShowRestaurant() 
        {
            return RedirectToAction("ListeRestaurant","Restaurant");
        }

    }
}