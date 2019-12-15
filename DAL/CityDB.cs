using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DTO;

namespace DAL
{
    public class CityDB : ICityDB
    {

        public string connectionString = null;
        public CityDB(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        //Retourne la ville en fonction de son ID
        public City GetCity(int id)
        {

            City city = null;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from City WHERE Id = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {

                            city = new City();
                            city.IdCity = (int)dr["Id"];

                            city.Zip_code = (int)dr["zip_code"];

                            city.Name = (string)dr["name"];
                           
                        }
                    }
                }
            }

            catch (Exception e)
            {
                throw e;
            }

            return city;
        }

       
    }
}
