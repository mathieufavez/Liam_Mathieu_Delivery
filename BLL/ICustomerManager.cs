using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using DAL;

namespace BLL
{
    public interface ICustomerManager
    {
        ICustomerDB CustomerDB { get; }
        List<Customer> GetAllCustomers();

        Customer GetCustomer(int id);

        int UpdateCustomer(Customer customer);

        int DeleteCustomer(int id);

        Customer AddCustomer(Customer customer);
    }
}
