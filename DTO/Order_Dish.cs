using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Order_Dish
    {
        public int IdOrder_Dish { get; set; }
        public string Quantity { get; set; }

        public int FK_idOrder { get; set; }

        public int FK_idDish { get; set; }


        public override string ToString()
        {
            return $"{IdOrder_Dish}|{Quantity}|{FK_idOrder}|{FK_idDish}";
        }
    }
}
