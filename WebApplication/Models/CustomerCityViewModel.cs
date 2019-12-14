using System;
using System.Collections.Generic;
using System.Linq;
using DTO;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class CustomerCityViewModel
    {
        public DTO.Customer Customers { get; set; }
        public DTO.City Cities { get; set; }
    }
}
