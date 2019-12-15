using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using DAL;

namespace BLL
{
    public interface ICustomerManager
    {
        int GetIdCustomer(string login);

        string GetPassword(int id, string login);

        string Code(int id);

        Customer GetCustomer(int idCustomer);
    }
}
