using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Deliveryman
    {


        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }



        public override string ToString()
        {
            return $"{Login}|{Password}";
        }
    }
}
