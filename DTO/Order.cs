using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Order
    {
        public int IdOrder { get; set; }
        public string Status { get; set; }

        public DateTime Created_at { get; set; }
        public int FK_idCustomer { get; set; }

        public int FK_idDelivery_Time { get; set; }

        public override string ToString()
        {
            return $"{IdOrder}|{Status}|{Created_at}|{FK_idCustomer}|{FK_idDelivery_Time}";
        }
    }
}
