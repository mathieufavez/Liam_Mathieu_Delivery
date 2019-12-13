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
    public class Order_DishController : Controller
    {
        private IOrder_DishManager Order_DishManager { get; }

        public Order_DishController(IOrder_DishManager order_dishManager)
        {
            Order_DishManager = order_dishManager;
        }

        public ActionResult ListOrder_Dish()
        {

            int idOrder = HttpContext.Session.GetInt32("IdOrder").GetValueOrDefault();
            var order_dishes = Order_DishManager.GetAllOrder_Dish(idOrder);
            return View(order_dishes);
        }

        public ActionResult AddDish()
        {
            //Remontrer la vue avec les order DIsh choisis
            return RedirectToAction("ListeDishes", "Dish");
        }

        public ActionResult CreateOrder_Dish() 
        {
            int quantite = HttpContext.Session.GetInt32("Quantite").GetValueOrDefault();
            int idDish = HttpContext.Session.GetInt32("IdDish").GetValueOrDefault();
            int idOrder = HttpContext.Session.GetInt32("IdOrder").GetValueOrDefault();
            Order_Dish newOrder_Dish = new Order_Dish {FK_idDish=idDish, FK_idOrder = idOrder, Quantity=quantite };
            Order_DishManager.AddOrder_Dish(newOrder_Dish);
            return RedirectToAction("ListOrder_Dish", "Order_Dish");
        }

        public ActionResult ChooseDeliveryTime() 
        {
            return RedirectToAction("ChooseDeliveryTime","Delivery_Time");
        }

        [HttpGet]
        public IActionResult GetQuantity()
        {
            return View();
        }

       [HttpPost]
        public IActionResult GetQuantity(Order_Dish order_dish)
        {

            HttpContext.Session.SetInt32("Quantite", order_dish.Quantity);
            return RedirectToAction("CreateOrder_Dish","Order_Dish");
        }


    }
}