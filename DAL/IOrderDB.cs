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

        Order GetOrder(int id);

        int UpdateOrder(Order order);

        int DeleteOrder(int id);

        Order AddOrder(Order order);
    }
}
