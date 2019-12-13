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
    public class Order_DishController : Controller
    {
        private IOrder_DishManager Order_DishManager { get; }
        private IDishManager DishManager { get; }

        public Order_DishController(IOrder_DishManager order_dishManager, IDishManager dishManager)
        {
            Order_DishManager = order_dishManager;
            DishManager = dishManager;
        }

        /*public ActionResult ListOrder_Dish()
        {

            int idOrder = HttpContext.Session.GetInt32("IdOrder").GetValueOrDefault();
            var order_dishes = Order_DishManager.GetAllOrder_Dish(idOrder);
            return View(order_dishes);
        }*/

        public ActionResult ListOrder_Dish()
        {
            int idOrder = HttpContext.Session.GetInt32("IdOrder").GetValueOrDefault();
            List<DTO.Order_Dish> listeOrderDish = Order_DishManager.GetAllOrder_Dish(idOrder);
            List<DishOrderDishViewModel> dishOrderDish = new List<DishOrderDishViewModel>();
            foreach (DTO.Order_Dish o in listeOrderDish)
            {
                DishOrderDishViewModel dishOrderDishViewModel = new DishOrderDishViewModel();
                dishOrderDishViewModel.Order_Dishes = o;
                dishOrderDishViewModel.Dishes = DishManager.GetDish(o.FK_idDish);
                dishOrderDish.Add(dishOrderDishViewModel);
            }
            return View(dishOrderDish);
        }

        public ActionResult AddDish()
        {
            //Remontrer la vue avec les order DIsh choisis
            return RedirectToAction("ListeDishes", "Dish");
        }

       /* public ActionResult CreateOrder_Dish() 
        {
            int quantite = HttpContext.Session.GetInt32("Quantite").GetValueOrDefault();
            int idDish = HttpContext.Session.GetInt32("IdDish").GetValueOrDefault();
            int idOrder = HttpContext.Session.GetInt32("IdOrder").GetValueOrDefault();

            Order_Dish newOrder_Dish = new Order_Dish {FK_idDish=idDish, FK_idOrder = idOrder, Quantity=quantite };
            Order_DishManager.AddOrder_Dish(newOrder_Dish);
            return RedirectToAction("ListOrder_Dish", "Order_Dish");
        }*/

        public ActionResult CreateOrder_Dish()
        {
            int quantite = HttpContext.Session.GetInt32("Quantite").GetValueOrDefault();
            int idDish = HttpContext.Session.GetInt32("IdDish").GetValueOrDefault();
            int idOrder = HttpContext.Session.GetInt32("IdOrder").GetValueOrDefault();
            //int dishPrice = HttpContext.Session.GetInt32("DishPrice").GetValueOrDefault();
            DTO.Order_Dish newOrder_Dish = new DTO.Order_Dish { FK_idDish = idDish, FK_idOrder = idOrder, Quantity=quantite };
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
        public IActionResult GetQuantity(DTO.Order_Dish order_dish)
        {
            HttpContext.Session.SetInt32("Quantite", order_dish.Quantity);
            return RedirectToAction("CreateOrder_Dish","Order_Dish");
        }
    }
}