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

        public int GetidCityFromRestaurant(int idRestaurant) 
        {
            return RestaurantDBObject.GetidCityFromRestaurant(idRestaurant);
        }

        public Restaurant GetRestaurant(int id)
        {
            return RestaurantDBObject.GetRestaurant(id);
        }

        public int UpdateRestaurant(Restaurant restaurant)
        {
            return RestaurantDBObject.UpdateRestaurant(restaurant);
        }

        public Restaurant AddRestaurant(Restaurant restaurant)
        {
            return RestaurantDBObject.AddRestaurant(restaurant);
        }
    }
}
