using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DTO;

namespace DAL
{
    public class RestaurantDB : IRestaurantDB
    {
        public string connectionString = null;
        public RestaurantDB(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        //Retourne une liste de tous les restaurants
        public List<Restaurant> GetAllRestaurants()
        {
            List<Restaurant> results = null;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Restaurant";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Restaurant>();

                            Restaurant restaurant = new Restaurant();

                            restaurant.IdRestaurant = (int)dr["Id"];
                            restaurant.Name = (string)dr["name"];
                            restaurant.Merchant_name = (string)dr["merchant_name"];
                            restaurant.Address = (string)dr["address"];
                            restaurant.FK_idCity = (int)dr["FK_idCity"];


                            results.Add(restaurant);
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


        //Retourne un restaurant en fonction de son ID
        public Restaurant GetRestaurant(int id)
        {

            Restaurant restaurant = new Restaurant();

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Restaurant WHERE Id=@id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {

                            restaurant.IdRestaurant = (int)dr["Id"];
                            restaurant.Name = (string)dr["name"];
                            restaurant.Merchant_name = (string)dr["merchant_name"];
                            restaurant.Address = (string)dr["address"];
                            restaurant.FK_idCity = (int)dr["FK_idCity"];


                        }
                    }
                }
            }

            catch (Exception e)
            {
                throw e;
            }

            return restaurant;
        }

    }
}
