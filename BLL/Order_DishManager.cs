using System.Collections.Generic;
using DAL;
using DTO;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    public class Order_DishManager
    {
        public IOrder_DishDB Order_DishDB { get; }

        public Order_DishManager(IConfiguration configuration)
        {
            Order_DishDB = new Order_DishDB(configuration);
        }
        public List<Order_Dish> GetAllOrder_Dish()
        {
            return Order_DishDB.GetAllOrder_Dish();
        }

        public Order_Dish GetOrder_Dish(int id)
        {
            return Order_DishDB.GetOrder_Dish(id);
        }

        public int UpdateOrder_Dish(Order_Dish order_Dish)
        {
            return Order_DishDB.UpdateOrder_Dish(order_Dish);
        }
        public int DeleteOrder_Dish(int id)
        {
            return Order_DishDB.DeleteOrder_Dish(id);
        }

        public Order_Dish AddOrder_Dish(Order_Dish order_Dish)
        {
            return Order_DishDB.AddOrder_Dish(order_Dish);
        }
    }
}
