using System.Collections.Generic;
using DTO;
using DAL;

namespace BLL
{
    public interface IDeliveryManager
    {

        List<Delivery> GetAllDelivery(int deliverymanID);

        Delivery GetDelivery(int id);

        void UpdateDelivery(int idDelivery, int idDeliveryman);

        Delivery AddDelivery(Delivery delivery);

        int GetNombreDeliveryALivrerPourUnDeliveryman(int idDeliveryman);

    }
}
