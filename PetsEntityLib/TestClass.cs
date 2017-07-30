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
            using (PetShopDBContext _context = new PetShopDBContext())
            {
                _context.Database.Log = Console.WriteLine;
                var cus = new Customer()
                {
                    ADDRESS = "vsdvdfv",
                    AGE = 5,
                    FIRSTNAME = "csv",
                    LASTNAME = "efgbn",
                    Courses = GetJoinCustomerCourseManyToMany()
                };
                _context.Customers.Add(cus);
                _context.SaveChanges();
            }
        }

        public static void ManyToManyCourse()
        {
            using (PetShopDBContext _context = new PetShopDBContext())
            {
                var course = new Course()
                {
                    NAME = "Customer test 1",
                    SUBJECT_TYPE = "Custimer test",
                    Customers = GetJoinManyToManyCustomer()
                };
                _context.Courses.Add(course);
                _context.SaveChanges();
            }
        }

        private static List<JoinCustomerCourse> GetJoinCustomerCourseManyToMany()
        {
            return new List<JoinCustomerCourse>()
            {
                new JoinCustomerCourse()
                {
                    CUSTOMER_ID = 1,
                    //COURSE_ID = 1
                    Course = new Course()
                    {
                        NAME = "test course 1",
                        SUBJECT_TYPE = "test subject 1"
                    }
                },
                new JoinCustomerCourse()
                {
                    CUSTOMER_ID = 1,
                    //COURSE_ID = 2
                    Course = new Course()
                    {
                        NAME = "test course 2",
                        SUBJECT_TYPE = "test subject 2"
                    }
                },
                new JoinCustomerCourse()
                {
                    CUSTOMER_ID = 1,
                    //COURSE_ID = 3
                    Course = new Course()
                    {
                        NAME = "test course 3",
                        SUBJECT_TYPE = "test subject 3"
                    }
                },
                new JoinCustomerCourse()
                {
                    CUSTOMER_ID = 1,
                    //COURSE_ID = 4
                    Course = new Course()
                    {
                        NAME = "test course 4",
                        SUBJECT_TYPE = "test subject 4"
                    }
                }
            };
        }

        private static List<JoinCustomerCourse> GetJoinManyToManyCustomer()
        {
            return new List<JoinCustomerCourse>()
            {
                new JoinCustomerCourse()
                {
                    Customer = new Customer()
                    {
                        ADDRESS = "vsdvdfv customer 1",
                        AGE = 5,
                        FIRSTNAME = "csv customer 1",
                        LASTNAME = "efgbn customer 1",
                    },
                    COURSE_ID = 1
                },
                new JoinCustomerCourse()
                {
                    Customer = new Customer()
                    {
                        ADDRESS = "vsdvdfv customer 2",
                        AGE = 5,
                        FIRSTNAME = "csv customer 2",
                        LASTNAME = "efgbn customer 2",
                    },
                    COURSE_ID = 2
                },
                new JoinCustomerCourse()
                {
                    Customer = new Customer()
                    {
                        ADDRESS = "vsdvdfv customer 3",
                        AGE = 5,
                        FIRSTNAME = "csv customer 3",
                        LASTNAME = "efgbn customer 3",
                    },
                    COURSE_ID = 3
                },
                new JoinCustomerCourse()
                {
                    Customer = new Customer()
                    {
                        ADDRESS = "vsdvdfv customer 4",
                        AGE = 5,
                        FIRSTNAME = "csv customer 4",
                        LASTNAME = "efgbn customer 4",
                    },
                    COURSE_ID = 4
                }
            };
        }
    }
}
