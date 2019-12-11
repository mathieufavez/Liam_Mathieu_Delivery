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

        //Disply all the dishes
        public List<Dish> GetAllDishes(int idRestaurant)
        {
            List<Dish> results = null;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Dish WHERE FK_idRestaurant="+idRestaurant+";";
                    SqlCommand cmd = new SqlCommand(query, cn);

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
                            dish.Status = (string)dr["status"];
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

        //Add 1 dish
        public Dish AddDish(Dish dish)
        {

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "INSERT into Dish(name) values(@name); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@name", dish.Name);


                    cn.Open();

                    dish.IdDish = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return dish;
        }

        //Display 1 city with his ID given
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


        public int GetDishPrice(int idDish)
        {

            int dishPrice = 0;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select price from Dish WHERE Id = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", idDish);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {

                           
                            dishPrice = (int)dr["price"];

                         

                        }
                    }
                }
            }

            catch (Exception e)
            {
                throw e;
            }

            return dishPrice;
        }

        //Update 1 Dish with his ID given
        public int UpdateDish(Dish dish)
        {
            int result = 0;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Dish set name=@name WHERE Id=@id;";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", dish.IdDish);
                    cmd.Parameters.AddWithValue("@name", dish.Name);


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


        //Delete 1 Dish with his ID given
        public int DeleteDish(int id)
        {
            int result = 0;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Dish WHERE Id=@id;";
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
