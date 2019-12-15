using System.Collections.Generic;
using DTO;
using DAL;

namespace BLL
{
    public interface IOrderManager
    {

        List<Order> GetAllOrders();

        void UpdateOrder(int id, string status);

        void UpdateOrderDeliveryTime(int id, int idDeliveryTime);


        Order AddOrder(Order order);

        List<Order> GetAllOrdersForOneCustomer(int idCustomer);

        Order GetOrder(int idOrder);


    }
}
