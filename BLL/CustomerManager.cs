using System.Collections.Generic;
using DAL;
using DTO;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    public class CustomerManager
    {
        public ICustomerDB CustomerDB { get; }

        public CustomerManager(IConfiguration configuration)
        {
            CustomerDB = new CustomerDB(configuration);
        }
        public List<Customer> GetAllCustomers()
        {
            return CustomerDB.GetAllCustomers();
        }

        public int GetIdCustomer(string login)
        {
            return CustomerDB.GetIdCustomer(login);
        }

        public int UpdateCustomer(Customer customer)
        {
            return CustomerDB.UpdateCustomer(customer);
        }
        public int DeleteCustomer(int id)
        {
            return CustomerDB.DeleteCustomer(id);
        }

        public string GetPassword(int id, string login) {

            return CustomerDB.GetPassword(id,login);
        }

        public Customer AddCustomer(Customer customer)

            //check city

            //if not then create new

            //NEW CUSTOMER

        {
            return CustomerDB.AddCustomer(customer);
        }
        public string Code(int id)
        {
            return CustomerDB.Code(id);
        }
    }
}
