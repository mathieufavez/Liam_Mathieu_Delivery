using System.Collections.Generic;
using DTO;
using DAL;

namespace BLL
{
    public interface IDeliverymanManager
    {
        IDeliverymanDB DeliverymanDB { get; }
        List<Deliveryman> GetAllDeliveryman();

        Deliveryman GetDeliveryman(int id);

        int UpdateDeliveryman(Deliveryman deliveryman);

        int DeleteDeliveryman(int id);

        Deliveryman AddDeliveryman(Deliveryman deliveryman);

        string GetPassword(int id, string login);
    }
}
