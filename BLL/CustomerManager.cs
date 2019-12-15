using System.Collections.Generic;
using DAL;
using DTO;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    public class CustomerManager : ICustomerManager
    {
        public ICustomerDB CustomerDB { get; }

        public CustomerManager(ICustomerDB customerDB)
        {
            CustomerDB = customerDB;
        }

        public int GetIdCustomer(string login)
        {
            return CustomerDB.GetIdCustomer(login);
        }

        public string GetPassword(int id, string login) {

            return CustomerDB.GetPassword(id,login);
        }

        public string Code(int id)
        {
            return CustomerDB.Code(id);
        }

        public Customer GetCustomer(int idCustomer) 
        {
            return CustomerDB.GetCustomer(idCustomer);
        }

    }
}
