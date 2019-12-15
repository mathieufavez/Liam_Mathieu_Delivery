using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DTO;

namespace DAL
{
    public class DishDB : IDishDB
    {
        public string connectionString = null;
        public DishDB(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        //Retourne tous les Dish en fonction du restaurant
        public List<Dish> GetAllDishes(int idRestaurant)
        {
            List<Dish> results = new List<Dish>();

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Dish WHERE FK_idRestaurant=@idRestaurant";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idRestaurant", idRestaurant);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Dish>();

                            Dish dish = new Dish();

                            dish.IdDish = (int)dr["Id"];
                            dish.Name = (string)dr["name"];
                            dish.Price = (int)dr["price"];
                            dish.FK_idRestaurant = (int)dr["FK_idRestaurant"];




                            results.Add(dish);
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

        //Retourn un Dish en fonction de son ID
        public Dish GetDish(int id)
        {

            Dish dish = null;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Dish WHERE Id = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {

                            dish = new Dish();
                            dish.IdDish = (int)dr["id"];

                            dish.Name = (string)dr["name"];
                            dish.Price = (int)dr["price"];

                        }
                    }
                }
            }

            catch (Exception e)
            {
                throw e;
            }

            return dish;
        }
    }
}
