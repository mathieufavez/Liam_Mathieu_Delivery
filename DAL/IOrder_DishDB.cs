using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;


namespace DAL
{
    public interface IOrder_DishDB
    {
         IConfiguration Configuration { get; }

        List<Order_Dish> GetAllOrder_Dish();

        Order_Dish GetOrder_Dish(int id);

        int UpdateOrder_Dish(Order_Dish order_dish);

        int DeleteOrder_Dish(int id);

        Order_Dish AddOrder_Dish(Order_Dish order_dish);
    }
}
