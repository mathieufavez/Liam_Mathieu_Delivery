﻿using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IRestaurantDB
    { 
        List<Restaurant> GetAllRestaurants();

        Restaurant GetRestaurant(int id);
    }
}
