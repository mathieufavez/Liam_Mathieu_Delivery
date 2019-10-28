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

        List<Dish> GetAllDishes();

        Dish GetDish(int id);

        int UpdateDish(Dish dish);

        int DeleteDish(int id);

        Dish AddDish(Dish dish);
    }
}
