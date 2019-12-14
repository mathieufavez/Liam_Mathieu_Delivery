
using System.Collections.Generic;
using DAL;
using DTO;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    public class Delivery_TimeManager : IDelivery_TimeManager
    {
        public IDelivery_TimeDB Delivery_TimeDB { get; }

        public Delivery_TimeManager(IDelivery_TimeDB deliveryTimeDB)
        {
            Delivery_TimeDB = deliveryTimeDB;
        }
        public List<Delivery_Time> GetAllDelivery_Time()
        {
            return Delivery_TimeDB.GetAllDelivery_Time();
        }

        public Delivery_Time GetDelivery_Time(int id) 
        {
            return Delivery_TimeDB.GetDelivery_Time( id);
        }



    }
}