using System.Collections.Generic;
using DTO;
using DAL;

namespace BLL
{
    public interface ICityManager
    {
        List<City> GetAllCities();

        City GetCity(int id);

        int UpdateCity(City city);

        int DeleteCity(int id);

        City AddCity(City city);

        int GetIdCity(string nameCity, string zipCity);
    }
}
