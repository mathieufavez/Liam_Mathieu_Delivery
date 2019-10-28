using System.Collections.Generic;
using DAL;
using DTO;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    public class OrderManager
    {
        public IOrderDB OrderDB { get; }

        public OrderManager(IConfiguration configuration)
        {
            OrderDB = new OrderDB(configuration);
        }
        public List<Order> GetAllOrders()
        {
            return OrderDB.GetAllOrders();
        }

        public Order GetOrder(int id)
        {
            return OrderDB.GetOrder(id);
        }

        public int UpdateOrder(Order order)
        {
            return OrderDB.UpdateOrder(order);
        }
        public int DeleteOrder(int id)
        {
            return OrderDB.DeleteOrder(id);
        }

        public Order AddOrder(Order order)
        {
            return OrderDB.AddOrder(order);
        }
    }
}
