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

        //Disply all the cities
        public List<City> GetAllCities()
        {
            List<City> results = null;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM City";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<City>();

                            City city = new City();

                            city.IdCity = (int)dr["Id"];
                            city.Name = (string)dr["name"];


                            results.Add(city);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return results;
        }

        public City AddCity(City city)
        {


            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "INSERT into City(name, zip_code) values(@name, @zip_code); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@name", city.Name);
                    cmd.Parameters.AddWithValue("@zip_code", city.Zip_code);


                    cn.Open();

                    city.IdCity = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return city;
        }

        //Display 1 city with his ID given
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

        public int GetIdCity(string nameCity, string zipCity)
        {

            int idCity=0;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select Id from City WHERE name=@nameCity AND zip_code=@zipCity";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@nameCity", nameCity);
                    cmd.Parameters.AddWithValue("@zipCity", zipCity);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {

                          
                            idCity = (int)dr["Id"];

                           

                        }
                    }
                }
            }

            catch (Exception e)
            {
                throw e;
            }

            return idCity;
        }


        //Update 1 city with his ID given
        public int UpdateCity(City city)
        {
            int result = 0;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE City set name=@name WHERE Id=@id;";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", city.IdCity);
                    cmd.Parameters.AddWithValue("@name", city.Name);
                    

                    cn.Open();

                    result = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }


        //Delete 1 city with his ID given
        public int DeleteCity(int id)
        {
            int result = 0;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM City WHERE Id=@id;";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    result = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }



    }
}
