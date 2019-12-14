using System.Collections.Generic;
using DAL;
using DTO;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    public class DeliveryManager : IDeliveryManager
    {
        public IDeliveryDB DeliveryDB { get; }

        public DeliveryManager(IDeliveryDB deliveryDB)
        {
            DeliveryDB = deliveryDB;
        }
        public List<Delivery> GetAllDelivery(int deliverymanID)
        {
            return DeliveryDB.GetAllDelivery(deliverymanID);
        }

        public Delivery GetDelivery(int id)
        {
            return DeliveryDB.GetDelivery(id);
        }

        public void UpdateDelivery(int idDelivery, int idDeliveryman)
        {
            DeliveryDB.UpdateDelivery(idDelivery, idDeliveryman);
        }

        public Delivery AddDelivery(Delivery delivery)
        {
            return DeliveryDB.AddDelivery(delivery);
        }

        public int GetNombreDeliveryALivrerPourUnDeliveryman(int idDeliveryman)
        {
            return DeliveryDB.GetNombreDeliveryALivrerPourUnDeliveryman(idDeliveryman);
        }

    }
}
