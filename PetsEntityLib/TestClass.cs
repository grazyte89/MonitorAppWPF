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
        public static List<Customer> GetCustomers()
        {
            List<Customer> customer;

            using (PetShopDBContext _context = new PetShopDBContext())
            {
                customer = _context.Customers.ToList();
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

        public static void ManyTwoManyTest()
        {
            List<Coursem2m> litscourse2m2 = new List<Coursem2m>()
            {
                new Coursem2m()
                {
                    NAME_MM = "test 1",
                    SUBJECT_TYPE_MM = "Subject don't know"
                },
                new Coursem2m()
                {
                    NAME_MM = "subject 2",
                    SUBJECT_TYPE_MM = "Subject don't know"
                },
                new Coursem2m()
                {
                    NAME_MM = "subject 3",
                    SUBJECT_TYPE_MM = "Subject don't know"
                },
                new Coursem2m()
                {
                    NAME_MM = "subject 4",
                    SUBJECT_TYPE_MM = "Subject don't know"
                }
            };

            using (PetShopDBContext _context = new PetShopDBContext())
            {
                var cus = new Customer()
                {
                    ADDRESS = "vsdvdfv",
                    AGE = 5,
                    FIRSTNAME = "csv",
                    LASTNAME = "efgbn",
                    CourseMany2Manys = litscourse2m2
                };
                _context.Customers.Add(cus);
                _context.SaveChanges();
            }
        }
    }
}
