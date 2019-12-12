using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Restaurant
    {
        public int IdRestaurant { get; set; }

        public string Name { get; set; }
        public string Merchant_name { get; set; }

        public string Address { get; set; }

        public int FK_idCity { get; set; }

        public override string ToString()
        {
            return $"{IdRestaurant}|{Name}|{Merchant_name}|{Address}|{FK_idCity}";
        }
    }
}
