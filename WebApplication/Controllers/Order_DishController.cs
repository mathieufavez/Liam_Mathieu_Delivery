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

        //Vue affichant le "panier", le client arrive sur cette page et choisi d'ajouter un plat, qui va être affiché avec la quantité qu'il a choisi
        //Affiche ensuite le total de la commande actuelle 
        //Il peut ajouter autant de plats qu'il veut
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

        //Lorsque le client clique sur ajouter un plat, il est redirigé vers la liste des plats
        public ActionResult AddDish()
        {
            
            return RedirectToAction("ListeDishes", "Dish");
        }

        //Lorsque le client a choisi son plat et la quantité, l'order_dish est crée et retourne la vue liste des Order_dish
        public ActionResult CreateOrder_Dish()
        {
            int quantite = HttpContext.Session.GetInt32("Quantite").GetValueOrDefault();
            int idDish = HttpContext.Session.GetInt32("IdDish").GetValueOrDefault();
            int idOrder = HttpContext.Session.GetInt32("IdOrder").GetValueOrDefault();
            int priceDish = HttpContext.Session.GetInt32("DishPrice").GetValueOrDefault();
            int total = quantite * priceDish;

            DTO.Order_Dish newOrder_Dish = new DTO.Order_Dish { FK_idDish = idDish, FK_idOrder = idOrder, Quantity=quantite , Total = total};
            Order_DishManager.AddOrder_Dish(newOrder_Dish);
            return RedirectToAction("ListOrder_Dish", "Order_Dish");
        }

        //Lorsque le client choisi son heure, il est redirigé vers le controlleur Delivery_time
        public ActionResult ChooseDeliveryTime() 
        {
            return RedirectToAction("ChooseDeliveryTime","Delivery_Time");
        }

        //Le client indique combien de quantité il veut
        [HttpGet]
        public IActionResult GetQuantity()
        {
            return View();
        }

        //Reprend la quantité choisi par le client et redirige vers CreateOrder_Dish
       [HttpPost]
        public IActionResult GetQuantity(DTO.Order_Dish order_dish)
        {
            HttpContext.Session.SetInt32("Quantite", order_dish.Quantity);
            return RedirectToAction("CreateOrder_Dish","Order_Dish");
        }

        //Si un client a choisi un plat et ne le veut plus, il peut le supprimer pour qu'il ne soit pas sur sa commande
        //Redirige vers la listeOrder_Dish
        public ActionResult DeleteOrder_Dish(int idOrder_Dish) 
        {
            Order_DishManager.DeleteOrder_Dish(idOrder_Dish);
            return RedirectToAction("ListOrder_Dish", "Order_Dish");
        }
    }
}