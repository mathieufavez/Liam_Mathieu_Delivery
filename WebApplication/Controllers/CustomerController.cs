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

        private ICustomerManager CustomerManager { get; }
        private ICityManager CityManager { get; }

        public CustomerController(ICustomerManager customerManager, ICityManager cityManager)
        {
            CustomerManager = customerManager;
            CityManager = cityManager;
        }

        //Vue pour que l'utilisateur insère son login et mot de passe
        [HttpGet]
        public IActionResult Connexion()
        {
            return View();
        }

        //Reprend les insertions de l'utilisateur et regarde si cela correspond à la BD
        [HttpPost]
        public IActionResult Connexion(Customer customer)
        {

            int idCustomer = CustomerManager.GetIdCustomer(customer.Login);
            string password = CustomerManager.GetPassword(idCustomer, customer.Login);
            //Si ca correspond, passe à la vue HomeCustomer
            if (customer.Password == password)
            {

                HttpContext.Session.SetInt32("IdCustomer", idCustomer);
                return RedirectToAction("HomeCustomer", "Customer");
            }

            //Si ca ne correspond pas, reste sur la vue
            else
            {
                return View();
            }
        }

        //Accueil customer, affiche son nom et son adresse via le Modele CustomerCityViewModel
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

        //Lorsque l'utilisateur clique sur Nouvelle commande, redirige vers la liste des restaurants
        public ActionResult ShowRestaurant() 
        {
            return RedirectToAction("ListeRestaurant","Restaurant");
        }

    }
}