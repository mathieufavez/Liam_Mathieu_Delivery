using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IDeliverymanDB
    {

        List<Deliveryman> GetAllDeliveryman(int idCity);

        int GetIdDeliveryman(string login);

        int UpdateDeliveryman(Deliveryman deliveryman);

        Deliveryman AddDeliveryman(Deliveryman deliveryman);

        string GetPassword(int id, string login);

        int GetRightDeliveryman(int idRestaurant);

        Deliveryman GetDeliveryman(int idDeliveryman);

    }
}
