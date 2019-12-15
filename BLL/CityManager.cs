using System.Collections.Generic;
using DAL;
using DTO;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    public class CityManager : ICityManager
    {
        public ICityDB CityDB { get; }

        public CityManager(ICityDB cityDB)
        {
            CityDB = cityDB;
        }

        public City GetCity(int id)
        {
            return CityDB.GetCity(id);
        }

    }
}
