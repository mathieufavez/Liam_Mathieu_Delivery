﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Restaurant
    {
        public int IdRestaurant { get; set; }

        public string Name { get; set; }
        public string Merchant_name { get; set; }

        public string Address { get; set; }

        public int FK_idCity { get; set; }

    }
}
