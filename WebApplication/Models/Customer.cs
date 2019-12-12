using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Customer
    {
    

        public string Login { get; set; }

        public string Password { get; set; }


        public override string ToString()
        {
            return $"{Login}|{Password}";
        }
    }
}
