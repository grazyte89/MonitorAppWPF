using PetsEntityLib.DataBaseContext;
using PetsEntityLib.DataBasePersistances;
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
            var messages = new List<Message>();

            using (PetShopDBContext _context = new PetShopDBContext())
            {
                customer = _context.Customers.Find(9162);
                courses = _context.Courses.ToList();
                /*messages = _context.Messages.Where(m => m.SENDER_ID == 9162)
                            .ToList();*/
            }

            var coursecustomer = courses.Where(c => c.ID < 10).Select(c => new JoinCustomerCourse
            {
                CUSTOMER_ID = customer.ID,
                COURSE_ID = c.ID
            }).ToList();

            customer.Courses = coursecustomer;

            foreach (var message in messages)
            {
                message.MESSAGE_HEAD = "updated messgae";
                message.TEXT = "I can now start working on something else";
            }

            using (PetShopDBContext _dbcontext = new PetShopDBContext())
            {
                for (int cycle = 0; cycle < 5; cycle++)
                {
                    Message message = new Message()
                    {
                        MESSAGE_HEAD = "test message",
                        SENDER = "Need to put id",
                        RECEIVER = "Definitly need to put id",
                        CREATE_DATE = DateTime.Now,
                        SEND_BY_DATE = DateTime.Now,
                        TEXT = "Well i guess i'm making changes to this table next",
                        SENDER_ID = customer.ID
                    };

                    messages.Add(message);
                }
            }

            customer.Messages = messages;

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

        public static void TestAccountClass()
        {
            Customer customer;

            using (PetShopDBContext _context = new PetShopDBContext())
            {
                customer = _context.Customers.Find(9162);
            }

            CreateAccountClass createAccount = new CreateAccountClass(null);
            createAccount.CreateAccount(customer.ID);
            createAccount.SaveCreatedItems();
        }

        public static void TestTransactionClass()
        {
            Account account1;
            Account account2;

            using (PetShopDBContext _context = new PetShopDBContext())
            {
                account1 = _context.Accounts.Find(1);
                account2 = _context.Accounts.Find(2);
            }

            CreateTransactionClass transaction = new CreateTransactionClass(null);
            transaction.CreateTransaction(account1.ID, account2.ID, 500);
            transaction.SaveCreatedItems();
        }
    }
}
