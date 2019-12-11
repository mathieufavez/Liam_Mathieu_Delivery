using System.Collections.Generic;
using DAL;
using DTO;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    public class RestaurantManager
    {
        public IRestaurantDB RestaurantDB { get; }

        public RestaurantManager(IConfiguration configuration)
        {
            RestaurantDB = new RestaurantDB(configuration);
        }
        public List<Restaurant> GetAllRestaurants()
        {
            return RestaurantDB.GetAllRestaurants();
        }

        public int GetidCityFromRestaurant(int idRestaurant) 
        {
            return RestaurantDB.GetidCityFromRestaurant(idRestaurant);
        }

        public Restaurant GetRestaurant(int id)
        {
            return RestaurantDB.GetRestaurant(id);
        }

        public int UpdateRestaurant(Restaurant restaurant)
        {
            return RestaurantDB.UpdateRestaurant(restaurant);
        }

        public Restaurant AddRestaurant(Restaurant restaurant)
        {
            return RestaurantDB.AddRestaurant(restaurant);
        }
    }
}
