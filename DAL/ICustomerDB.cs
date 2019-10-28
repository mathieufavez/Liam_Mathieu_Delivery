using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public interface ICustomerDB
    {
        IConfiguration Configuration { get; }

        List<Customer> GetAllCustomers();

        Customer GetCustomer(int id);

        int UpdateCustomer(Customer customer);

        int DeleteCustomer(int id);

        Customer AddCustomer(Customer customer);
    }
}
