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

        //Disply all the restaurants
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

        public Restaurant AddRestaurant(Restaurant restaurant)
        {

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "INSERT into Restaurant(name, merchant_name, address, FK_idCity) values(@name, @merchant_name,@address,@FK_idCity); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@name", restaurant.Name);
                    cmd.Parameters.AddWithValue("@merchant_name", restaurant.Merchant_name);
                    cmd.Parameters.AddWithValue("@merchant_name", restaurant.Address);
                    cmd.Parameters.AddWithValue("@merchant_name", restaurant.FK_idCity);


                    cn.Open();

                    restaurant.IdRestaurant = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return restaurant;
        }

        //Display 1 city with his ID given
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


        //Update 1 city with his ID given
        public int UpdateRestaurant(Restaurant restaurant)
        {
            int result = 0;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Restaurant set name=@name WHERE Id=@id;";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", restaurant.IdRestaurant);
                    cmd.Parameters.AddWithValue("@name", restaurant.Name);


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
        public int DeleteRestaurant(int id)
        {
            int result = 0;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Restaurant WHERE Id=@id;";
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

        public int GetidCityFromRestaurant(int idRestaurant)
        {
            int result = 0;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT FK_idCity FROM Restaurant WHERE Id=@id;";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("Id", idRestaurant);
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
