using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface ICustomerDB
    {
        IConfiguration Configuration { get; }

        List<Customer> GetAllCustomers();

        int GetIdCustomer(string login);

        int UpdateCustomer(Customer customer);

        int DeleteCustomer(int id);

        Customer AddCustomer(Customer customer);

        string GetPassword(int id, string login);

        string Code(int id);
    }
}
