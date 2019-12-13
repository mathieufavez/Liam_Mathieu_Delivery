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
    public class OrderController : Controller
    {
        private IOrderManager OrderManager { get; }

        public OrderController(IOrderManager orderManager)
        {
            OrderManager = orderManager;
        }

        public ActionResult CreateOrder (int id)
        {
            int idCustomer = HttpContext.Session.GetInt32("IdCustomer").GetValueOrDefault();
            DTO.Order newOrder  = new DTO.Order { Status = "En cours", FK_idCustomer = idCustomer };
            OrderManager.AddOrder(newOrder);

            int idOrder = newOrder.IdOrder;
            HttpContext.Session.SetInt32("IdOrder", idOrder);
            return RedirectToAction("ListOrder_Dish", "Order_Dish");
        }
    }
}