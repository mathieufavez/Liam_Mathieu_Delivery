﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DTO;

namespace DAL
{
    public class Delivery_TimeDB : IDelivery_TimeDB
    {

        public IConfiguration Configuration { get; }
        public Delivery_TimeDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Delivery_Time> GetAllDelivery_Time()
        {
            List<Delivery_Time> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

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

        public string GetDelivery_Time(int id)
        {

            string delivery_time = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select Delivery_Time from Delivery_Time WHERE Id = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {

                        

                            delivery_time = (string)dr["Delivery_Time"];

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
