using System.Collections.Generic;
using DAL;
using DTO;
using Microsoft.Extensions.Configuration;


namespace BLL
{
    public class DeliverymanManager
    {
        public IDeliverymanDB DeliverymanDB { get; }

        public DeliverymanManager(IConfiguration configuration)
        {
            DeliverymanDB = new DeliverymanDB(configuration);
        }
        public List<Deliveryman> GetAllDeliveryman()
        {
            return DeliverymanDB.GetAllDeliveryman();
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
        public int DeleteDeliveryman(int id)
        {
            return DeliverymanDB.DeleteDeliveryman(id);
        }

        public Deliveryman AddDeliveryman(Deliveryman deliveryman)
        {
            return DeliverymanDB.AddDeliveryman(deliveryman);
        }
    }
}
