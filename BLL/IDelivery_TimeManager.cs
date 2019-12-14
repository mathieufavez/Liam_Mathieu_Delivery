using System.Collections.Generic;
using DTO;
using DAL;
namespace BLL
{
    public interface IDelivery_TimeManager
    {
        List<Delivery_Time> GetAllDelivery_Time();

        Delivery_Time GetDelivery_Time(int id);
    }
}