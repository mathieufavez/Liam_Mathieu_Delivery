using System.Collections.Generic;
using DTO;
using DAL;

namespace BLL
{
    public interface IOrderManager
    {

        List<Order> GetAllOrders();

        int UpdateOrder(Order order);

        Order AddOrder(Order order);

        List<Order> GetAllOrdersForOneCustomer(int idCustomer);

        Order GetOrder(int idOrder);


    }
}
