using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DTO;

namespace DAL
{
    public class CustomerDB : ICustomerDB
    {

        public string connectionString = null;
        public CustomerDB(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        //Retourne le customer en fonction de son ID
        public Customer GetCustomer(int idCustomer)
        {

            Customer customer = null;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Customer WHERE Id = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", idCustomer);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {

                            customer = new Customer();
                            customer.IdCustomer = (int)dr["Id"];
                            customer.Name = (string)dr["name"];
                            customer.LastName = (string)dr["lastName"];
                            customer.Address = (string)dr["address"];
                            customer.Login = (string)dr["login"];
                            customer.Password = (string)dr["password"];
                            customer.FK_idCity = (int)dr["FK_idCity"];
                            if (dr["Code"] != DBNull.Value)
                                customer.Code = (string)dr["Code"];
                        }
                    }
                }
            }

            catch (Exception e)
            {
                throw e;
            }

            return customer;
        }

        //Trouver le customer en donnant son login
        public int GetIdCustomer(string login)
        {
            int idCustomer=0 ;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select Id from Customer WHERE login=@login";
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

        //Retourne le mot de passe du Customer en fonction de son ID et de son login
        public string GetPassword(int id, string login)
        {
            string password = null;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select password from Customer WHERE Id=@id AND login=@login";
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

        //Retourne le code d'annulation du Customer en fonction de son ID
        public string Code(int id)
        {
            string result = null;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT *, CONCAT(LEFT(UPPER(lastName), 2), LEFT(name, 1)) AS Code FROM CUSTOMER WHERE Id=@id ; ";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            result = (string)dr["Code"];
                        }
                    }
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
