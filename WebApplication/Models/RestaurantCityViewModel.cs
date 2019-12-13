using System;
using System.Collections.Generic;
using System.Linq;
using DTO;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class RestaurantCityViewModel
    {
        public DTO.Restaurant Restaurants { get; set; }
        public DTO.City Cities { get; set; }
    }
}
