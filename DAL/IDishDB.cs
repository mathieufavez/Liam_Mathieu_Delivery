using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;


namespace DAL
{
    public interface IDishDB
    {
        IConfiguration Configuration { get; }

        List<Dish> GetAllDishes(int idRestaurant);

        Dish GetDish(int id);

        int GetDishPrice(int idDish);

        int UpdateDish(Dish dish);

        int DeleteDish(int id);

        Dish AddDish(Dish dish);
    }
}
