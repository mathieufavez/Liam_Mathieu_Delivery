﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
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

    }
}
