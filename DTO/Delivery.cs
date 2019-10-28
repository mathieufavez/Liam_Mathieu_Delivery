using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Delivery
    {

        public int IdDelivery { get; set; }
        public string Created_at { get; set; }

        public int FK_idOrder { get; set; }

        public int FK_idRestaurant { get; set; }

        public override string ToString()
        {
            return $"{IdDelivery}|{Created_at}|{FK_idOrder}|{FK_idRestaurant}";
        }
    }
}
