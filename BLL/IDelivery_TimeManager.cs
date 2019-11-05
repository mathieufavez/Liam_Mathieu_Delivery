using System.Collections.Generic;
using DTO;
using DAL;
namespace BLL
{
    public interface IDelivery_TimeManager
    {
        IDelivery_TimeDB Delivery_TimeDB { get; }
        List<Delivery_Time> GetAllDelivey_Time();

        string GetDelivery_Time(int id);
    }
}