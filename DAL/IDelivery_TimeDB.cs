

using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IDelivery_TimeDB
    {

        List<Delivery_Time> GetAllDelivery_Time();

        Delivery_Time GetDelivery_Time(int id);
    }
}