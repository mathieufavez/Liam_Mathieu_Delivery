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

        //Disply all the deliveryman
        public List<Deliveryman> GetAllDeliveryman(int idCity)
        {
            List<Deliveryman> results = null;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Deliveryman WHERE FK_idCity=@idCity";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idCity", idCity);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Deliveryman>();

                            Deliveryman deliveryman = new Deliveryman();

                            deliveryman.IdDeliveryman = (int)dr["Id"];
                            deliveryman.Name = (string)dr["name"];
                            deliveryman.LastName = (string)dr["lastname"];
                            deliveryman.Address = (string)dr["address"];

                            if (dr["login"] != DBNull.Value)
                                deliveryman.Login = (string)dr["login"];

                            if (dr["password"] != DBNull.Value)
                                deliveryman.Password = (string)dr["password"];

                            if (dr["FK_idCity"] != DBNull.Value)
                                deliveryman.FK_idCity = (int)dr["FK_idCity"];


                            results.Add(deliveryman);
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

        public Deliveryman AddDeliveryman(Deliveryman deliveryman)
        {


            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "INSERT into Deliveryman(name, lastName, address, login, password, FK_iDCity, FK_idDelivery) values(@name,@lastName,@address,@login,@password,@FK_iDCity,@FK_idDelivery); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@name", deliveryman.Name);


                    cn.Open();

                    deliveryman.IdDeliveryman = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return deliveryman;
        }

        //Display 1 deliverman with his ID given
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


        //Update 1 deliveryman with his ID given
        public int UpdateDeliveryman(Deliveryman deliveryman)
        {
            int result = 0;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Deliveryman set name=@name WHERE Id=@id;";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", deliveryman.IdDeliveryman);
                    cmd.Parameters.AddWithValue("@name", deliveryman.Name);


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


        public int GetRightDeliveryman(int idRestaurant)
        {
            int result = 0;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT id FROM Deliveryman WHERE FK_idCity=@id;";
                    SqlCommand cmd = new SqlCommand(query, cn);

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
