using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IDeliverymanDB
    {

        string GetPassword(int id, string login);

        int GetRightDeliveryman(int idCity);

        Deliveryman GetDeliveryman(int idDeliveryman);

        int GetIdDeliveryman(string login);

    }
}
