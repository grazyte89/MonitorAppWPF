using PetsEntityLib.DataBaseContext;
using PetsEntityLib.Entities;
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

            using (PetShopDBContext _context = new PetShopDBContext())
            {
                customer = _context.Customers.ToList();
                //customer = new List<Customer>();
            }

            return customer;
        }

        public static void CreateCustomer(string firstname, string lastname)
        {
            using (PetShopDBContext _context = new PetShopDBContext())
            {
                Customer customer = new Customer();
                customer.FIRSTNAME = firstname;
                customer.LASTNAME = lastname;
                customer.AGE = 25;
                customer.ADDRESS = "Test address + " + firstname + " " + lastname;
                _context.Customers.Add(customer);
                _context.SaveChanges();
            }
        }
    }
}
