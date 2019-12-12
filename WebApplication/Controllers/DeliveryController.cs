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
    public class DeliveryController : Controller
    {
        private IDeliveryManager DeliveryManager { get; }

        public DeliveryController(IDeliveryManager deliveryManager)
        {
            DeliveryManager = deliveryManager;
            
        }

    }
}