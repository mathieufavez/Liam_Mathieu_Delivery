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

        int GetIdCustomer(string login);

        int UpdateCustomer(Customer customer);

        int DeleteCustomer(int id);

        Customer AddCustomer(Customer customer);

        string GetPassword(int id, string login);

        string Code(int id);
    }
}
