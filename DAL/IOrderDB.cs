using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IOrderDB
    {
        IConfiguration Configuration { get; }

        List<Order> GetAllOrders();

        int UpdateOrder(Order order);

        Order AddOrder(Order order);

        List<Order> GetAllOrdersForOneCustomer(int idCustomer);
    }
}
