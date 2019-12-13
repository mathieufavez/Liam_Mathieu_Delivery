using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL;
using DAL;
using DTO;

namespace WebApplication.Controllers
{
    public class Delivery_TimeController : Controller
    {
        private IDelivery_TimeManager Delivery_TimeManager { get; }

        public Delivery_TimeController(IDelivery_TimeManager delivery_timeManager)
        {
            Delivery_TimeManager = delivery_timeManager;
        }


        public ActionResult ChooseDeliveryTime() 
        {
            var delivery_times = Delivery_TimeManager.GetAllDelivery_Time();
            return View(delivery_times);
        }

        public ActionResult ChoixDelivery_Time(int id) 
        {
            HttpContext.Session.SetInt32("IdDelivery_Time", id);
            return RedirectToAction();
        }
    }
}