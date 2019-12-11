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

        public int UpdateOrder(Order order)
        {
            return OrderDB.UpdateOrder(order);
        }

        public Order AddOrder(Order order)
        {
            return OrderDB.AddOrder(order);
        }
        public List<Order> GetAllOrdersForOneCustomer(int idCustomer)
        {
            return OrderDB.GetAllOrdersForOneCustomer(idCustomer);
        }
    }
}
