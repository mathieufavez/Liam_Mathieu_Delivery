using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Order_Dish
    {
        public int IdOrder_Dish { get; set; }
        public int Quantity { get; set; }

        public int FK_idOrder { get; set; }

        public int FK_idDish { get; set; }

        public int Total { get; set; }

    }
}
