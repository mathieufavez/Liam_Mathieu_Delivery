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
      
            public IConfiguration Configuration { get; }
            public DeliverymanDB(IConfiguration configuration)
            {
                Configuration = configuration;
            }

            //Disply all the deliveryman
            public List<Deliveryman> GetAllDeliveryman()
            {
                List<Deliveryman> results = null;
                string connectionString = Configuration.GetConnectionString("DefaultConnection");

                try
                {
                    using (SqlConnection cn = new SqlConnection(connectionString))
                    {
                        string query = "SELECT * FROM Deliveryman";
                        SqlCommand cmd = new SqlCommand(query, cn);

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

                                if (dr["FK_idDelivery"] != DBNull.Value)
                                    deliveryman.FK_idDelivery = (int)dr["FK_idDelivery"];


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

                string connectionString = Configuration.GetConnectionString("DefaultConnection");

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
            public Deliveryman GetDeliveryman(int id)
            {

                Deliveryman deliveryman = null;
                string connectionString = Configuration.GetConnectionString("DefaultConnection");

                try
                {
                    using (SqlConnection cn = new SqlConnection(connectionString))
                    {
                        string query = "Select * from Deliveryman WHERE Id = @id";
                        SqlCommand cmd = new SqlCommand(query, cn);
                        cmd.Parameters.AddWithValue("@id", id);

                        cn.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {

                                deliveryman.IdDeliveryman = (int)dr["Id"];
                                deliveryman.LastName = (string)dr["lastname"];
                                deliveryman.Address = (string)dr["address"];
                                deliveryman.Login = (string)dr["login"];
                                deliveryman.Password = (string)dr["password"];
                                deliveryman.FK_idCity = (int)dr["FK_idCity"];
                                deliveryman.FK_idDelivery = (int)dr["FK_idDelivery"];

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


            //Update 1 deliveryman with his ID given
            public int UpdateDeliveryman(Deliveryman deliveryman)
            {
                int result = 0;
                string connectionString = Configuration.GetConnectionString("DefaultConnection");

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


            //Delete 1 deliveryman with his ID given
            public int DeleteDeliveryman(int id)
            {
                int result = 0;
                string connectionString = Configuration.GetConnectionString("DefaultConnection");

                try
                {
                    using (SqlConnection cn = new SqlConnection(connectionString))
                    {
                        string query = "DELETE FROM Deliveryman WHERE Id=@id;";
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
