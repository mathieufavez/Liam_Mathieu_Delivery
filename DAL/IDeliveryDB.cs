using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IDeliveryDB
    {

        List<Delivery> GetAllDelivery(int deliverymanID);

        Delivery GetDelivery(int id);

        int UpdateDelivery(Delivery delivery);

        int DeleteDelivery(int id);

        Delivery AddDelivery(Delivery delivery);
    }
}
