using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DTO;

namespace DAL
{
    public class Delivery_TimeDB : IDelivery_TimeDB
    {

        public string connectionString = null;
        public Delivery_TimeDB(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        //Retourne une liste de tous les Delivery_Time
        public List<Delivery_Time> GetAllDelivery_Time()
        {
            List<Delivery_Time> results = null;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Delivery_Time WHERE Delivery_Time.Delivery_Time >  CONVERT(VARCHAR(5), GETDATE(), 108);";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Delivery_Time>();

                            Delivery_Time delivery_time = new Delivery_Time();

                            delivery_time.IdDelivery_Time = (int)dr["Id"];
                            delivery_time.Delivery_time = (string)dr["Delivery_Time"];


                            results.Add(delivery_time);
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

        //Retourne un Delivery_Time en fonction de son ID
        public Delivery_Time GetDelivery_Time(int id)
        {

            Delivery_Time delivery_time = null;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Delivery_Time WHERE Id = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {

                            delivery_time = new Delivery_Time();
                            delivery_time.IdDelivery_Time = (int)dr["Id"];
                            delivery_time.Delivery_time = (string)dr["Delivery_Time"];

                        }
                    }
                }
            }

            catch (Exception e)
            {
                throw e;
            }

            return delivery_time;
        }
    }
}
