using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DTO;

namespace DAL
{
    public class DeliveryDB : IDeliveryDB
    {
        public string connectionString = null;
        public DeliveryDB(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        //Disply all the delivery
        public List<Delivery> GetAllDelivery(int deliverymanID)
        {
            List<Delivery> results = null;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Delivery WHERE FK_idDeliveryman=@Id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("Id", deliverymanID);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Delivery>();

                            Delivery delivery = new Delivery();

                            delivery.IdDelivery = (int)dr["Id"];
                            delivery.Created_at = (DateTime)dr["created_at"];
                            delivery.FK_idOrder = (int)dr["FK_idOrder"];
                            delivery.FK_idRestaurant = (int)dr["FK_idRestaurant"];
                            delivery.FK_idDelivery_Time = (int)dr["FK_idDelivery_Time"];
                            delivery.FK_idDeliveryman = (int)dr["FK_idDeliveryman"];


                            results.Add(delivery);
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

        public Delivery AddDelivery(Delivery delivery)
        {


            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "INSERT into Delivery(created_at) values(@created_at); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@created_at", delivery.Created_at);


                    cn.Open();

                    delivery.IdDelivery = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return delivery;
        }

        //Display 1 city with his ID given
        public Delivery GetDelivery(int id)
        {

            Delivery delivery = null;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Delivery WHERE Id = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {

                            delivery = new Delivery();
                            delivery.IdDelivery = (int)dr["Id"];

                            delivery.Created_at = (DateTime)dr["created_at"];

                        }
                    }
                }
            }

            catch (Exception e)
            {
                throw e;
            }

            return delivery;
        }


        //Update 1 delivery with his ID given
        public int UpdateDelivery(Delivery delivery)
        {
            int result = 0;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Delivery set name=@name WHERE Id=@id;";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", delivery.IdDelivery);
                    cmd.Parameters.AddWithValue("@name", delivery.Created_at);


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
        public int DeleteDelivery(int id)
        {
            int result = 0;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Delivery WHERE Id=@id;";
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
