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

        void UpdateDelivery(int idDelivery, int idDeliveryman);

        Delivery AddDelivery(Delivery delivery);

        int GetNombreDeliveryALivrerPourUnDeliveryman(int idDeliveryman);

        void UpdateDeliveryStatus(int idDelivery, string status);


    }
}
