using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;

namespace WebApplication.Models
{
    public class OrderDetailsViewModel
    {
        public DTO.Customer Customers { get; set; }
        public DTO.City Cities { get; set; }
      

        public DTO.Order Orders { get; set; }

        public DTO.Restaurant Restaurants { get; set; }

        public DTO.Order_Dish Order_Dishes { get; set; }

        public DTO.Dish Dishes { get; set; }

        public DTO.Delivery_Time Delivery_Times { get; set; }

    }
}
