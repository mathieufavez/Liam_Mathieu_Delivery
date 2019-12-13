using System.Collections.Generic;
using DAL;
using DTO;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    public class OrderManager : IOrderManager
    {
        public IOrderDB OrderDBObject { get; }

        public OrderManager(IOrderDB orderDB)
        {
            OrderDBObject = orderDB;
        }
        public List<Order> GetAllOrders()
        {
            return OrderDBObject.GetAllOrders();
        }

        public int UpdateOrder(Order order)
        {
            return OrderDBObject.UpdateOrder(order);
        }

        public Order AddOrder(Order order)
        {
            return OrderDBObject.AddOrder(order);
        }
        public List<Order> GetAllOrdersForOneCustomer(int idCustomer)
        {
            return OrderDBObject.GetAllOrdersForOneCustomer(idCustomer);
        }

    }
}
