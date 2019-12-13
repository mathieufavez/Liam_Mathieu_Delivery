using System;
using System.Collections.Generic;
using System.Linq;
using DTO;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class DishOrderDishViewModel
    {
        public DTO.Dish Dishes { get; set; }
        public DTO.Order_Dish Order_Dishes { get; set; }
    }
}