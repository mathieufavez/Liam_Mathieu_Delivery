using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
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
