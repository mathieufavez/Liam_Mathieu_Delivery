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
        
        public IConfiguration Configuration { get; }
        public CustomerDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //Affiche tous les customers
        public List<Customer> GetAllCustomers()
        {
            List<Customer> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Customer";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Customer>();

                            Customer customer = new Customer();

                            customer.IdCustomer = (int)dr["Id"];
                            customer.Name = (string)dr["name"];
                            customer.LastName = (string)dr["lastName"];
                            customer.Address = (string)dr["address"];

                            if (dr["login"] != DBNull.Value)
                                customer.Login = (string)dr["login"];

                            if (dr["password"] != DBNull.Value)
                                customer.Password = (string)dr["password"];

                            if (dr["FK_idCity"] != DBNull.Value)
                                customer.FK_idCity = (int)dr["FK_idCity"];

                            if (dr["FK_idDelivery"] != DBNull.Value)
                                customer.FK_idDelivery = (int)dr["FK_idDelivery"];

                            results.Add(customer);
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

        //Trouver le customer en donnant son ID
        public Customer GetCustomer(int id)
        {

            Customer customer = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Customer WHERE Id = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {

                            customer.IdCustomer = (int)dr["Id"];
                            customer.Name = (string)dr["name"];
                            customer.LastName = (string)dr["lastName"];
                            customer.Address = (string)dr["address"];
                            customer.Login = (string)dr["login"];
                            customer.Password = (string)dr["password"];
                            customer.FK_idCity = (int)dr["FK_idCity"];
                            customer.FK_idDelivery = (int)dr["FK_idDelivery"];

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

        public Customer AddCustomer(Customer customer)
        {

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "INSERT into Customer(Name, LastName, Address, Login, Password, FK_idCity) values (@name, @lastname, @address, @login, @password, @fkidcity); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@name", customer.Name);
                    cmd.Parameters.AddWithValue("@lastname", customer.LastName);
                    cmd.Parameters.AddWithValue("@address", customer.Address);
                    cmd.Parameters.AddWithValue("@login", customer.Login);
                    cmd.Parameters.AddWithValue("@password", customer.Password);
                    cmd.Parameters.AddWithValue("@fkidcity", customer.FK_idCity);
                    cn.Open();


                    customer.IdCustomer = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return customer;
        }


        //Change le nom du customer en donnant son ID
        public int UpdateCustomer(Customer customer)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Customer set name=@name WHERE Id=@id;";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", customer.IdCustomer);
                    cmd.Parameters.AddWithValue("@name", customer.Name);


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
        //Delete customer en donnant son ID
        public int DeleteCustomer(int id)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Customer WHERE Id=@id;";
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
