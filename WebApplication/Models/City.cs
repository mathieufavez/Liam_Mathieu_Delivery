using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class City
    {
        public int IdCity { get; set; }

        public int Zip_code { get; set; }
        public string Name { get; set; }


        public override string ToString()
        {
            return $"{IdCity}|{Name}|{Zip_code}";
        }
    }
}
