using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Dish
    {
        public int IdDish { get; set; }
        public string Name { get; set; }

        public int Price { get; set; }

        public string Status { get; set; }

        public string Created_at { get; set; }

        public int FK_idRestaurant { get; set; }

        public override string ToString()
        {
            return $"{IdDish}|{Name}|{Price}|{Status}|{Created_at}|{FK_idRestaurant}";
        }
    }
}
