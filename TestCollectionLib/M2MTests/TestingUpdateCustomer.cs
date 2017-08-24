using PetsEntityLib.DataBaseContext;
using PetsEntityLib.DataBaseUpdates;
using PetsEntityLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCollectionLib.M2MTests
{
    public class TestingUpdateCustomer
    {
        public static void TestManyToMay()
        {
            using (PetShopDBContext _context = new PetShopDBContext())
            {
                var course = new Course()
                {
                    NAME = "Customer 111 test 1",
                    SUBJECT_TYPE = "Custimer 111 test",
                    Customers = GetJoinManyToManyCustomer()
                };
                _context.Courses.Add(course);
                _context.SaveChanges();
            }

            Customer customer;
            List<Course> courses;

            using (PetShopDBContext _context = new PetShopDBContext())
            {
                customer = _context.Customers.Find(9162);
                courses = _context.Courses.ToList();
            }

            var coursecustomer = courses.Where(c => c.ID < 100).Select(c => new JoinCustomerCourse
            {
                CUSTOMER_ID = customer.ID,
                COURSE_ID = c.ID
            }).ToList();
            coursecustomer.Add(new JoinCustomerCourse
            {
                CUSTOMER_ID = customer.ID,
                Course = new Course
                {
                    NAME = "NewTest12",
                    SUBJECT_TYPE = "idon'tknow"
                }
            });
            customer.Courses = coursecustomer;

            UpdateCustomerClass updateCustomer = new UpdateCustomerClass(customer);
            updateCustomer.SaveUpdate();
        }

        private static List<JoinCustomerCourse> GetJoinManyToManyCustomer()
        {
            return new List<JoinCustomerCourse>()
            {
                new JoinCustomerCourse()
                {
                    Customer = new Customer()
                    {
                        ADDRESS = "tesstupdatecustomer customer 1",
                        AGE = 5,
                        FIRSTNAME = "tesstupdatecustomer customer 1",
                        LASTNAME = "tesstupdatecustomer customer 1",
                    },
                    COURSE_ID = 1
                },
                new JoinCustomerCourse()
                {
                    Customer = new Customer()
                    {
                        ADDRESS = "tesstupdatecustomer customer 2",
                        AGE = 5,
                        FIRSTNAME = "tesstupdatecustomer customer 2",
                        LASTNAME = "tesstupdatecustomer customer 2",
                    },
                    COURSE_ID = 2
                },
                new JoinCustomerCourse()
                {
                    Customer = new Customer()
                    {
                        ADDRESS = "tesstupdatecustomer customer 3",
                        AGE = 5,
                        FIRSTNAME = "tesstupdatecustomer customer 3",
                        LASTNAME = "tesstupdatecustomer customer 3",
                    },
                    COURSE_ID = 3
                },
                new JoinCustomerCourse()
                {
                    Customer = new Customer()
                    {
                        ADDRESS = "tesstupdatecustomer customer 4",
                        AGE = 5,
                        FIRSTNAME = "tesstupdatecustomer customer 4",
                        LASTNAME = "tesstupdatecustomer customer 4",
                    },
                    COURSE_ID = 4
                }
            };
        }
    }
}
