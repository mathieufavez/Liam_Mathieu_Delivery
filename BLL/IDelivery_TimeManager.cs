using System.Collections.Generic;
using DTO;
using DAL;
namespace BLL
{
    public interface IDelivery_TimeManager
    {
        List<Delivery_Time> GetAllDelivery_Time();

        string GetDelivery_Time(int id);
    }
}