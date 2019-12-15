using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;

namespace WebApplication.Models
{
    public class DeliveryDetailsViewModel
    {
        public DTO.Delivery Deliverys { get; set; }

        public DTO.Order Orders { get; set; }

        public DTO.Restaurant Restaurants { get; set; }

        public DTO.Delivery_Time Delivery_Times { get; set; }
        public DTO.Customer Customers { get; set; }
        public DTO.City Cities { get; set; }
    }
}
