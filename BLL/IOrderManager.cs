using System.Collections.Generic;
using DTO;
using DAL;

namespace BLL
{
    public interface IOrderManager
    {

        IOrderDB OrderDB { get; }
        List<Order> GetAllOrders();

        Order GetOrder(int id);

        int UpdateOrder(Order order);

        int DeleteOrder(int id);

        Order AddOrder(Order order);
    }
}
