using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Dish
    {
        public int IdDish { get; set; }
        public string Name { get; set; }

        public int Price { get; set; }

        public int FK_idRestaurant { get; set; }

        public override string ToString()
        {
            return $"{IdDish}|{Name}|{Price}|{FK_idRestaurant}";
        }
    }
}
