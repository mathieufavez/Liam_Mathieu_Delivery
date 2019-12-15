
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Delivery_Time
    {
        public int IdDelivery_Time { get; set; }

        public string Delivery_time { get; set; }

        public override string ToString()
        {
            return $"{IdDelivery_Time}|{Delivery_time}";
        }
    }
}
