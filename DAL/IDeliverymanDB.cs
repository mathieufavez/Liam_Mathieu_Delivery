using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IDeliverymanDB
    {
        IConfiguration Configuration { get; }

        List<Deliveryman> GetAllDeliveryman(int idCity);

        int GetIdDeliveryman(string login);

        int UpdateDeliveryman(Deliveryman deliveryman);

        Deliveryman AddDeliveryman(Deliveryman deliveryman);

        string GetPassword(int id, string login);
    }
}
