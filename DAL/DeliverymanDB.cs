using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DTO;

namespace DAL
{
    public class DeliverymanDB : IDeliverymanDB
    {

        public string connectionString = null;

        public DeliverymanDB(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        //Retourne le Deliveryman en fonction de son ID
        public Deliveryman GetDeliveryman(int idDeliveryman)
        {

            Deliveryman deliveryman = null;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Deliveryman WHERE Id = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", idDeliveryman);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {

                            deliveryman = new Deliveryman();
                            deliveryman.IdDeliveryman = (int)dr["Id"];
                            deliveryman.Name = (string)dr["name"];
                            deliveryman.LastName = (string)dr["lastName"];
                            deliveryman.Address = (string)dr["address"];
                            deliveryman.Login = (string)dr["login"];
                            deliveryman.Password = (string)dr["password"];
                            deliveryman.FK_idCity = (int)dr["FK_idCity"];
                        }
                    }
                }
            }

            catch (Exception e)
            {
                throw e;
            }

            return deliveryman;
        }

        //Retourne le mot de passe du Deliveryman en fonction de son login et de son ID
        public string GetPassword(int id, string login)
        {
            string password = null;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select password from Deliveryman WHERE Id=@id AND login=@login";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("login", login);
                    cmd.Parameters.AddWithValue("Id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {

                            password = (string)dr["password"];
                        }
                    }
                }
            }

            catch (Exception e)
            {
                throw e;
            }
            return password;
        }

        //Retourne l'Id du deliveryman adapté pour effectuer la livraison (Ne prend pas en compte la tranche de 30 minutes)
        public int GetRightDeliveryman(int idCity)
        {
            int result = 0;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT DISTINCT TOP(1) Deliveryman.Id FROM ((Deliveryman INNER JOIN Restaurant ON Deliveryman.FK_idCity=Restaurant.FK_idCity) INNER JOIN Delivery ON Delivery.FK_idRestaurant=Restaurant.Id ) WHERE Deliveryman.FK_idCity=@idCity AND Delivery.status='A livrer' GROUP BY Deliveryman.Id HAVING COUNT(status) < 5";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idCity", idCity);

                    cn.Open();

                    result = Convert.ToInt32(cmd.ExecuteScalar());
                        
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }

        //Retourne l'ID du Deliveryman en fonction de son login
        public int GetIdDeliveryman(string login)
        {
            int idCustomer = 0;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select Id from Deliveryman WHERE login=@login";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("login", login);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {

                            idCustomer = (int)dr["Id"];
                        }
                    }
                }
            }

            catch (Exception e)
            {
                throw e;
            }
            return idCustomer;
        }

    }
}
