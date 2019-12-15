using System.Collections.Generic;
using DAL;
using DTO;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    public class RestaurantManager : IRestaurantManager
    {
        public IRestaurantDB RestaurantDBObject { get; }

        public RestaurantManager(IRestaurantDB restaurantDB) 
        {
            RestaurantDBObject = restaurantDB;
        }
        public List<Restaurant> GetAllRestaurants()
        {
            return RestaurantDBObject.GetAllRestaurants();
        }

        public Restaurant GetRestaurant(int id)
        {
            return RestaurantDBObject.GetRestaurant(id);
        }
    }
}
