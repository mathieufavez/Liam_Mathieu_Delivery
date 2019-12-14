using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DTO;

namespace DAL
{
    public class OrderDB : IOrderDB
    {
        public string connectionString = null;
        public OrderDB(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        //Disply all the orders
        public List<Order> GetAllOrders()
        {
            List<Order> results = new List<Order>();

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Order";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Order>();

                            Order order = new Order();

                            order.IdOrder = (int)dr["Id"];
                            order.Status = (string)dr["status"];
                            order.Created_at = (DateTime)dr["created_at"];
                            order.FK_idCustomer = (int)dr["FK_idCustomer"];


                            results.Add(order);
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

        public Order GetOrder(int idOrder)
        {

            Order order = null;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from [Order] WHERE Id = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", idOrder);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {

                            order = new Order();
                            order.IdOrder = (int)dr["Id"];
                            order.Status = (string)dr["status"];
                            order.Created_at = (DateTime)dr["created_at"];
                            order.FK_idCustomer = (int)dr["FK_idCustomer"];


                        }
                    }
                }
            }

            catch (Exception e)
            {
                throw e;
            }

            return order;
        }

        //Add 1 order
        public Order AddOrder(Order order)
        {


            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "INSERT into [Order](status, FK_idCustomer) values(@status, @idCustomer); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@status", order.Status);
                    cmd.Parameters.AddWithValue("@idCustomer", order.FK_idCustomer);

                    cn.Open();

                    order.IdOrder = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return order;
        }



        //Update 1 order with his ID given
        public int UpdateOrder(Order order)
        {
            int result = 0;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Order set status=@status WHERE Id=@id;";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", order.IdOrder);
                    cmd.Parameters.AddWithValue("@status", order.Status);


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


        //Get all orders for one customer with the customer id
        public List<Order> GetAllOrdersForOneCustomer(int idCustomer)
        {
            List<Order> results = new List<Order>();

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM [Order] WHERE FK_idCustomer=@idCustomer";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idCustomer", idCustomer);
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Order>();

                            Order order = new Order();

                            order.IdOrder = (int)dr["Id"];
                            order.Status = (string)dr["status"];
                            order.Created_at = (DateTime)dr["created_at"];
                            order.FK_idCustomer = (int)dr["FK_idCustomer"];

                            results.Add(order);
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

       
    }
}

