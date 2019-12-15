using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface ICustomerDB
    {
        int GetIdCustomer(string login);

        string GetPassword(int id, string login);

        string Code(int id);

        Customer GetCustomer(int idCustomer);
    }
}
