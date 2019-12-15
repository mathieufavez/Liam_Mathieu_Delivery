using System.Collections.Generic;
using DTO;
using DAL;

namespace BLL
{
    public interface IDishManager
    {
        List<Dish> GetAllDishes(int idRestaurant);

        Dish GetDish(int id);

    }
}
