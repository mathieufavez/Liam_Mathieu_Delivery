using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Order_Dish
    {
        public int IdOrder_Dish { get; set; }
        public int Quantity { get; set; }

        public int FK_idOrder { get; set; }

        public int FK_idDish { get; set; }


        public override string ToString()
        {
            return $"{IdOrder_Dish}|{Quantity}|{FK_idOrder}|{FK_idDish}";
        }
    }
}
