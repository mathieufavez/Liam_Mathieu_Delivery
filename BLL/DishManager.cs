using System.Collections.Generic;
using DAL;
using DTO;
using Microsoft.Extensions.Configuration;


namespace BLL
{
    public class DishManager : IDishManager
    {
        public IDishDB DishDBObject { get; }

        public DishManager(IDishDB dishDB)
        {
            DishDBObject = dishDB;
        }
        public List<Dish> GetAllDishes(int idRetaurant)
        {
            return DishDBObject.GetAllDishes(idRetaurant);
        }

        public Dish GetDish(int id)
        {
            return DishDBObject.GetDish(id);
        }
    }
}
