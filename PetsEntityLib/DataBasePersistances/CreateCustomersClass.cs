using PetsEntityLib.DataBaseContext;
using PetsEntityLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsEntityLib.DataBasePersistances
{
    public class CreateCustomersClass : IDBPersistance<Customer>
    {
        private List<Customer> _customers;

        public CreateCustomersClass()
        {
            _customers = new List<Customer>();
        }

        public void CreateCustomer(string firstName, string lastName, int age, string address)
        {
            //_dbContext.Customers.Add()
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
                        _dbContext.Customers.AddRange(_customers);
                }
                _customers.Clear();
            }
            catch (Exception exception)
            {

            }
        }
    }
}
