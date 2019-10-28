﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DTO;

namespace DAL
{
    public class Order_DishDB : IOrder_DishDB
    {
        public IConfiguration Configuration { get; }
        public Order_DishDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //Disply all the order_dish
        public List<Order_Dish> GetAllOrder_Dish()
        {
            List<Order_Dish> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Order_Dish";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Order_Dish>();

                            Order_Dish order_Dish = new Order_Dish();

                            order_Dish.IdOrder_Dish = (int)dr["Id"];
                            order_Dish.Quantity = (string)dr["quantity"];
                            order_Dish.FK_idOrder = (int)dr["FK_idOrder"];
                            order_Dish.FK_idDish = (int)dr["FK_idDish"];


                            results.Add(order_Dish);
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

        //Ajoute 1 Order_Dish
        public Order_Dish AddOrder_Dish(Order_Dish order_Dish)
        {

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "INSERT into Order_Dish(quantity) values(@quantity); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@quantity", order_Dish.Quantity);


                    cn.Open();

                    order_Dish.IdOrder_Dish = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return order_Dish;
        }

        //Display 1 Order_Dish with his ID given
        public Order_Dish GetOrder_Dish(int id)
        {

            Order_Dish order_Dish = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Order_Dish WHERE Id=@id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {

                            order_Dish.IdOrder_Dish = (int)dr["Id"];
                            order_Dish.Quantity = (string)dr["quantity"];
                            order_Dish.FK_idOrder = (int)dr["FK_idOrder"];
                            order_Dish.FK_idDish = (int)dr["FK_idDish"];

                        }
                    }
                }
            }

            catch (Exception e)
            {
                throw e;
            }

            return order_Dish;
        }


        //Update 1 Order_Dish with his ID given
        public int UpdateOrder_Dish(Order_Dish order_dish)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Order_Dish set quantity=@quantity WHERE Id=@id;";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", order_dish.IdOrder_Dish);
                    cmd.Parameters.AddWithValue("@quantity", order_dish.Quantity);


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
        public int DeleteOrder_Dish(int id)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Order_Dish WHERE Id=@id;";
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