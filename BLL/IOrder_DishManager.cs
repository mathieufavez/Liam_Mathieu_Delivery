using System.Collections.Generic;
using DTO;
using DAL;

namespace BLL
{
    public interface IOrder_DishManager
    {
        List<Order_Dish> GetAllOrder_Dish(int idOrder);

        Order_Dish GetOrder_Dish(int id);

        int UpdateOrder_Dish(Order_Dish order_Dish);

        int DeleteOrder_Dish(int id);

        Order_Dish AddOrder_Dish(Order_Dish order_Dish);
    }
}
