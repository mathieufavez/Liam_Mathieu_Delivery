using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface ICityDB
    {
        IConfiguration Configuration { get; }

        List<City> GetAllCities();

        City GetCity(int id);

        int GetIdCity(string nameCity, string zipCity);

        int UpdateCity(City city);

        int DeleteCity(int id);

        City AddCity(City city);
    }
}
