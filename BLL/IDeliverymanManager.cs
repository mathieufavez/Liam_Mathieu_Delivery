using System.Collections.Generic;
using DTO;
using DAL;

namespace BLL
{
    public interface IDeliverymanManager
    {
        List<Deliveryman> GetAllDeliveryman(int idCity);

        int GetIdDeliveryman(string login);

        int UpdateDeliveryman(Deliveryman deliveryman);

        Deliveryman AddDeliveryman(Deliveryman deliveryman);

        string GetPassword(int id, string login);

        int GetRightDeliveryman(int idRestaurant);
    }
}
