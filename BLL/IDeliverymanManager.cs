using System.Collections.Generic;
using DTO;
using DAL;

namespace BLL
{
    public interface IDeliverymanManager
    {
        string GetPassword(int id, string login);

        int GetRightDeliveryman( int idCity);

        Deliveryman GetDeliveryman(int idDeliveryman);

        int GetIdDeliveryman(string login);


    }
}
