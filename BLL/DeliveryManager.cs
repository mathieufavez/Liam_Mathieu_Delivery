using System.Collections.Generic;
using DAL;
using DTO;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    public class DeliveryManager
    {
        public IDeliveryDB DeliveryDB { get; }

        public DeliveryManager(IConfiguration configuration)
        {
            DeliveryDB = new DeliveryDB(configuration);
        }
        public List<Delivery> GetAllDelivery(int deliverymanID)
        {
            return DeliveryDB.GetAllDelivery(deliverymanID);
        }

        public Delivery GetDelivery(int id)
        {
            return DeliveryDB.GetDelivery(id);
        }

        public int UpdateDelivery(Delivery delivery)
        {
            return DeliveryDB.UpdateDelivery(delivery);
        }
        public int DeleteDelivery(int id)
        {
            return DeliveryDB.DeleteDelivery(id);
        }

        public Delivery AddDelivery(Delivery delivery)
        {
            return DeliveryDB.AddDelivery(delivery);
        }
    }
}
