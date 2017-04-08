using PetsEntityLib.DataBaseContext;
using PetsEntityLib.Entities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsEntityLib.DataBasePersistances
{
    public class CreateCustomersClass : IDBPersistance<Customer>
    {
        private List<Customer> _customers;

        public CreateCustomersClass(List<Customer> customer)
        {
            _customers = customer;
        }

        public void CreateCustomer(string firstName, string lastName, int age, string address)
        {
            _customers.Add(new Customer()
            {
                FIRSTNAME = firstName,
                LASTNAME = lastName,
                AGE = age,
                ADDRESS = address
            });
        }

        public void AddChanges(Customer value)
        {
            if (value != null)
                _customers.Add(value);
        }

        public void SaveChanges()
        {
            try
            {
                using (PetShopDBContext _dbContext = new PetShopDBContext())
                {
                    if (_customers != null && _customers.Count > 0)
                    {
                        _dbContext.Customers.AddRange(_customers);
                        _dbContext.SaveChanges();
                    }
                }
                _customers.Clear();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Problem encountered during persisting customer." + 
                    "Message" + exception.Message);
            }
        }
    }
}
