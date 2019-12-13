using System.Collections.Generic;
using DAL;
using DTO;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    public class Order_DishManager : IOrder_DishManager
    {
        public IOrder_DishDB Order_DishDBObject { get; }

        public Order_DishManager(IOrder_DishDB order_dishDB)
        {
            Order_DishDBObject = order_dishDB;
        }
        public List<Order_Dish> GetAllOrder_Dish(int idOrder)
        {
            return Order_DishDBObject.GetAllOrder_Dish(idOrder);
        }

        public Order_Dish GetOrder_Dish(int id)
        {
            return Order_DishDBObject.GetOrder_Dish(id);
        }

        public int UpdateOrder_Dish(Order_Dish order_Dish)
        {
            return Order_DishDBObject.UpdateOrder_Dish(order_Dish);
        }
        public int DeleteOrder_Dish(int id)
        {
            return Order_DishDBObject.DeleteOrder_Dish(id);
        }

        public Order_Dish AddOrder_Dish(Order_Dish order_Dish)
        {
            return Order_DishDBObject.AddOrder_Dish(order_Dish);
        }
    }
}
