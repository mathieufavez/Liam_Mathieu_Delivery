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

        public Order AddOrder(Order order)
        {
            return OrderDBObject.AddOrder(order);
        }
        public List<Order> GetAllOrdersForOneCustomer(int idCustomer)
        {
            return OrderDBObject.GetAllOrdersForOneCustomer(idCustomer);
        }

        public Order GetOrder(int idOrder) 
        {
            return OrderDBObject.GetOrder(idOrder);
        }

        public void UpdateOrder(int id, string status) 
        {
            OrderDBObject.UpdateOrder(id,status);
        }

        public void UpdateOrderDeliveryTime(int id, int idDeliveryTime) 
        {
            OrderDBObject.UpdateOrderDeliveryTime(id, idDeliveryTime);
        }



    }
}
