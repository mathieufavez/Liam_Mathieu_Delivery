using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IOrderDB
    {
        List<Order> GetAllOrders();

        void UpdateOrder(int id, string status);

        void UpdateOrderDeliveryTime(int id, int idDeliveryTime);

        Order AddOrder(Order order);

        List<Order> GetAllOrdersForOneCustomer(int idCustomer);

        Order GetOrder(int idOrder);



    }
}
