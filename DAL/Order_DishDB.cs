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
        public string connectionString = null;

        public Order_DishDB(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        //Retourne une liste de tous les Order_Dish en fonction de l'ID de l'ordre
        public List<Order_Dish> GetAllOrder_Dish(int idOrder)
        {
            List<Order_Dish> results = new List<Order_Dish>();

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Order_Dish WHERE FK_idOrder=@idOrder";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idOrder", idOrder);
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Order_Dish>();

                            Order_Dish order_Dish = new Order_Dish();

                            order_Dish.IdOrder_Dish = (int)dr["Id"];


                            if (dr["quantity"] != DBNull.Value)
                                order_Dish.Quantity = (int)dr["quantity"];

                            order_Dish.FK_idOrder = (int)dr["FK_idOrder"];
                            order_Dish.FK_idDish = (int)dr["FK_idDish"];
                            order_Dish.Total=(int)dr["total"];

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
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "INSERT into Order_Dish(FK_idOrder, FK_idDish, quantity, total) values( @FK_idOrder, @FK_idDish, @quantity, @total); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    //cmd.Parameters.AddWithValue("@quantity", order_Dish.Quantity);
                    cmd.Parameters.AddWithValue("@FK_idOrder", order_Dish.FK_idOrder);
                    cmd.Parameters.AddWithValue("@FK_idDish", order_Dish.FK_idDish);
                    cmd.Parameters.AddWithValue("@quantity", order_Dish.Quantity);
                    cmd.Parameters.AddWithValue("@total", order_Dish.Total);

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

        //Retourne un Order_Dish en fonction de son ID
        public Order_Dish GetOrder_Dish(int id)
        {

            Order_Dish order_Dish = null;

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
                            if (dr["Id"] != DBNull.Value)
                                order_Dish.IdOrder_Dish = (int)dr["Id"];

                            if (dr["quantity"] != DBNull.Value)
                                order_Dish.Quantity = (int)dr["quantity"];

                            if (dr["FK_idOrder"] != DBNull.Value)
                                order_Dish.FK_idOrder = (int)dr["FK_idOrder"];

                            if (dr["FK_idDish"] != DBNull.Value)
                                order_Dish.FK_idDish = (int)dr["FK_idDish"];

                            if (dr["total"] != DBNull.Value)
                                order_Dish.Total = (int)dr["total"];

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

        //Ajoute la quantité à un Order_Dish
        public int UpdateOrder_Dish(Order_Dish order_dish)
        {
            int result = 0;

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
