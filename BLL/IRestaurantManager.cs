using System.Collections.Generic;
using DAL;
using DTO;

namespace BLL
{
    public interface IRestaurantManager
    {

        IRestaurantManager RestaurantDB { get; }
        List<Restaurant> GetAllRestaurants();

        Restaurant GetRestaurant(int id);

        int UpdateRestaurant(Restaurant restaurant);

        int DeleteRestaurant(int id);

        Restaurant AddRestaurant(Restaurant restaurant);
    }
}
