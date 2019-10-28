﻿using System.Collections.Generic;
using DTO;
using DAL;

namespace BLL
{
    public interface IDishManager
    {
        IDishDB DishDB { get; }
        List<Dish> GetAllDishes();

        Dish GetDish(int id);

        int UpdateDish(Dish dish);

        int DeleteDish(int id);

        Dish AddDish(Dish dish);
    }
}