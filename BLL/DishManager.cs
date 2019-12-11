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

        public int UpdateDish(Dish dish)
        {
            return DishDBObject.UpdateDish(dish);
        }
        public int DeleteDish(int id)
        {
            return DishDBObject.DeleteDish(id);
        }

        public Dish AddDish(Dish dish)
        {
            return DishDBObject.AddDish(dish);
        }

        public int GetDishPrice(int idDish)
        {
            return DishDBObject.GetDishPrice(idDish);
        }
    }
}
