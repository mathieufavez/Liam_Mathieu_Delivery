using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Order
    {
        public int IdOrder { get; set; }
        public string Status { get; set; }

        public string Created_at { get; set; }
        public int FK_idCustomer { get; set; }

        public override string ToString()
        {
            return $"{IdOrder}|{Status}|{Created_at}|{FK_idCustomer}";
        }
    }
}
