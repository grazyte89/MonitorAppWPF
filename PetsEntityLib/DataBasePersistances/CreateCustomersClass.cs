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
        private IList<Customer> _customers;

        public CreateCustomersClass(IList<Customer> customer)
        {
            if (customer != null)
                _customers = customer;
            else
                _customers = new List<Customer>();
        }

        public IList<Customer> Customers
        {
            get { return _customers; }
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

        public void AddItem(Customer value)
        {
            if (value != null)
                _customers.Add(value);
        }

        public void SaveCreatedItems()
        {
            try
            {
                using (PetShopDBContext _dbContext = new PetShopDBContext())
                {
                    if (_customers != null && _customers.Count > 0)
                    {
                        _dbContext.Customers.AddRange(_customers);
                        _dbContext.SaveChanges();
                        _customers.Clear();
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Problem encountered during persisting customer." + 
                    "Message" + exception.Message);
            }
        }
    }
}
