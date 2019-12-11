using System.Collections.Generic;
using DTO;
using DAL;

namespace BLL
{
    public interface IDishManager
    {
        List<Dish> GetAllDishes(int idRestaurant);

        Dish GetDish(int id);

        int UpdateDish(Dish dish);

        int DeleteDish(int id);

        Dish AddDish(Dish dish);

        int GetDishPrice(int idDish);
    }
}
