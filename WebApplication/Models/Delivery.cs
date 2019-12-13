﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Delivery
    {

        public int IdDelivery { get; set; }
        public DateTime Created_at { get; set; }

        public string Status { get; set; }

        public int FK_idOrder { get; set; }

        public int FK_idRestaurant { get; set; }

        public int FK_idDelivery_Time { get; set; }

        public int FK_idDeliveryman { get; set; }

        public override string ToString()
        {
            return $"{IdDelivery}|{Created_at}|{Status}|{FK_idOrder}|{FK_idRestaurant}|{FK_idDelivery_Time}|{FK_idDeliveryman}";
        }
    }
}