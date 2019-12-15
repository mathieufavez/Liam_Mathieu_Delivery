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
     
        public string GetPassword(int id, string login)
        {

            return DeliverymanDB.GetPassword(id, login);
        }

        public int GetRightDeliveryman(int idCity)
        {
             return DeliverymanDB.GetRightDeliveryman( idCity);
        }

        public Deliveryman GetDeliveryman(int idDeliveryman) 
        {
            return DeliverymanDB.GetDeliveryman(idDeliveryman);
        }
        public int GetIdDeliveryman(string login) 
        {
            return DeliverymanDB.GetIdDeliveryman(login);
        }


    }
}
