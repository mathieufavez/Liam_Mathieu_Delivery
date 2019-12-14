using System.Collections.Generic;
using DAL;
using DTO;
using Microsoft.Extensions.Configuration;


namespace BLL
{
    public class DeliverymanManager : IDeliverymanManager
    {
        public IDeliverymanDB DeliverymanDB { get; }
   

        public DeliverymanManager(IDeliverymanDB deliverymanDB)
        {
            DeliverymanDB = deliverymanDB;

        }
        public List<Deliveryman> GetAllDeliveryman(int idCity)
        {
            return DeliverymanDB.GetAllDeliveryman(idCity);
        }

        public int GetIdDeliveryman(string login)
        {
            return DeliverymanDB.GetIdDeliveryman(login);
        }

        public string GetPassword(int id, string login)
        {

            return DeliverymanDB.GetPassword(id, login);
        }

        public int UpdateDeliveryman(Deliveryman deliveryman)
        {
            return DeliverymanDB.UpdateDeliveryman(deliveryman);
        }
      
        public Deliveryman AddDeliveryman(Deliveryman deliveryman)
        {
            return DeliverymanDB.AddDeliveryman(deliveryman);
        }

        public int GetRightDeliveryman(int idRestaurant, int idCity)
        {
             return DeliverymanDB.GetRightDeliveryman(idRestaurant, idCity);
          
        }

        public Deliveryman GetDeliveryman(int idDeliveryman) 
        {
            return DeliverymanDB.GetDeliveryman(idDeliveryman);
        }

    }
}
