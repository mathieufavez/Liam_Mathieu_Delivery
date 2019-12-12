using System.Collections.Generic;
using DTO;
using DAL;

namespace BLL
{
    public interface IDeliveryManager
    {

        List<Delivery> GetAllDelivery(int deliverymanID);

        Delivery GetDelivery(int id);

        int UpdateDelivery(Delivery delivery);

        Delivery AddDelivery(Delivery delivery);

      
    }
}
