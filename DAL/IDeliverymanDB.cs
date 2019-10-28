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

        List<Deliveryman> GetAllDeliveryman();

        Deliveryman GetDeliveryman(int id);

        int UpdateDeliveryman(Deliveryman deliveryman);

        int DeleteDeliveryman(int id);

        Deliveryman AddDeliveryman(Deliveryman deliveryman);
    }
}
