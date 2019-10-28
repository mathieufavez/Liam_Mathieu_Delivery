using System.Collections.Generic;
using DAL;
using DTO;
using Microsoft.Extensions.Configuration;


namespace BLL
{
    public class DishManager
    {
        public IDishDB DishDB { get; }

        public DishManager(IConfiguration configuration)
        {
            DishDB = new DishDB(configuration);
        }
        public List<Dish> GetAllDishes()
        {
            return DishDB.GetAllDishes();
        }

        public Dish GetDish(int id)
        {
            return DishDB.GetDish(id);
        }

        public int UpdateDish(Dish dish)
        {
            return DishDB.UpdateDish(dish);
        }
        public int DeleteDish(int id)
        {
            return DishDB.DeleteDish(id);
        }

        public Dish AddDish(Dish dish)
        {
            return DishDB.AddDish(dish);
        }
    }
}
