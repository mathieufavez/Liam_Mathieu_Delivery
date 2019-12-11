using System.Collections.Generic;
using DAL;
using DTO;

namespace BLL
{
    public interface IRestaurantManager
    {

        List<Restaurant> GetAllRestaurants();

        Restaurant GetRestaurant(int id);

        int UpdateRestaurant(Restaurant restaurant);

        int GetidCityFromRestaurant(int idRestaurant);

        Restaurant AddRestaurant(Restaurant restaurant);
    }
}
