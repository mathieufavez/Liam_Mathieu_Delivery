using System.Collections.Generic;
using DTO;
using DAL;

namespace BLL
{
    public interface IDeliveryManager
    {

        IDeliveryDB DeliveryDB { get; }
        List<Delivery> GetAllDelivery(int deliverymanID);

        Delivery GetDelivery(int id);

        int UpdateDelivery(Delivery delivery);

        int DeleteDelivery(int id);

        Delivery AddDelivery(Delivery delivery);

      
    }
}
