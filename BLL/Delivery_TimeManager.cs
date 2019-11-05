
using System.Collections.Generic;
using DAL;
using DTO;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    public class Delivery_TimeManager
    {
        public IDelivery_TimeDB Delivery_TimeDB { get; }

        public Delivery_TimeManager(IConfiguration configuration)
        {
            Delivery_TimeDB = new Delivery_TimeDB(configuration);
        }
        public List<Delivery_Time> GetAllDelivery_Time()
        {
            return Delivery_TimeDB.GetAllDelivery_Time();
        }

        public string GetDelivery_Time(int id)
        {
            return Delivery_TimeDB.GetDelivery_Time(id);
        }



    }
}