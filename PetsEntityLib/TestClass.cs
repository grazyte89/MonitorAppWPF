using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsEntityLib
{
    public class TestClass
    {
        public static IList<Customer> GetCustomers()
        {
            IList<Customer> customer;

            using (PetsEContext _context = new PetsEContext())
            {
                customer = _context.Customers.ToList();
            }

            return customer;
        }
    }
}
