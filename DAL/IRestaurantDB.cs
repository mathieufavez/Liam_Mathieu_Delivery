using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IRestaurantDB
    {
        IConfiguration Configuration { get; }

        List<Restaurant> GetAllRestaurants();

        Restaurant GetRestaurant(int id);

        int UpdateRestaurant(Restaurant restaurant);

        int DeleteRestaurant(int id);

        Restaurant AddRestaurant(Restaurant restaurant);
    }
}
