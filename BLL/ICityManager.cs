using System.Collections.Generic;
using DTO;
using DAL;

namespace BLL
{
    public interface ICityManager
    {
        City GetCity(int id);
    }
}
