using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Deliveryman
    {

        public int IdDeliveryman { get; set; }
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public int FK_idCity { get; set; }

        public override string ToString()
        {
            return $"{IdDeliveryman}|{Name}|{LastName}|{Address}|{Login}|{Password}|{FK_idCity}";
        }
    }
}
