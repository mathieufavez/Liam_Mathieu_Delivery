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

        public Customer GetCustomer(int id)
        {
            return CustomerDB.GetCustomer(id);
        }

        public int UpdateCustomer(Customer customer)
        {
            return CustomerDB.UpdateCustomer(customer);
        }
        public int DeleteCustomer(int id)
        {
            return CustomerDB.DeleteCustomer(id);
        }

        public Customer AddCustomer(Customer customer)
        {
            return CustomerDB.AddCustomer(customer);
        }
    }
}
