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
        public List<City> GetAllCities()
        {
            return CityDB.GetAllCities();
        }

        public City GetCity(int id)
        {
            return CityDB.GetCity(id);
        }

        public int UpdateCity(City city) 
        {
            return CityDB.UpdateCity(city);
        }
        public int DeleteCity(int id)
        {
            return CityDB.DeleteCity(id);
        }

        public City AddCity(City city) 
        {
            return CityDB.AddCity(city);
        }

        public int GetIdCity(string nameCity, string zipCity) 
        {
            return CityDB.GetIdCity(nameCity, zipCity);
        }
    }
}
