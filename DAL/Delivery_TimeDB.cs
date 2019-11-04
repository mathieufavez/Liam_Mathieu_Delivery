using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DTO;

namespace DAL
{
    public class Delivery_TimeDB : IDelivery_TimeDB
    {

        public IConfiguration Configuration { get; }
        public Delivery_TimeDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}
