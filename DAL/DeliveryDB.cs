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

        public int GetNombreDeliveryALivrerPourUnDeliveryman(int idDeliveryman) 
        {
            int nbrDelivery = 0;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT COUNT(Id) FROM Delivery WHERE FK_idDeliveryman=@idDeliveryman AND status='A livrer'";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idDeliveryman", idDeliveryman);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                       
                            cn.Open();

                            nbrDelivery = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return nbrDelivery;
        }

        //Disply all the delivery
        public List<Delivery> GetAllDelivery(int deliverymanID)
        {
            List<Delivery> results = new List<Delivery>();

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Delivery WHERE FK_idDeliveryman=@Id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Id", deliverymanID);

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

                            if (dr["status"] != DBNull.Value)
                                delivery.Status = (string)dr["status"];

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
                    string query = "INSERT into Delivery(FK_idOrder, FK_idRestaurant, FK_idDelivery_Time, status) values( @FK_idOrder, @FK_idRestaurant, @FK_idDelivery_Time,  @status); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@status", delivery.Status);
                    cmd.Parameters.AddWithValue("@FK_idOrder", delivery.FK_idOrder);
                    cmd.Parameters.AddWithValue("@FK_idRestaurant", delivery.FK_idRestaurant);
                    cmd.Parameters.AddWithValue("@FK_idDelivery_Time", delivery.FK_idDelivery_Time);
                  


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
        public void UpdateDelivery(int idDelivery, int idDeliveryman)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Delivery set FK_idDeliveryman=@idDeliveryman WHERE Id=@idDelivery";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idDeliveryman", idDeliveryman);
                    cmd.Parameters.AddWithValue("@idDelivery", idDelivery);


                    cn.Open();

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

    }
}
