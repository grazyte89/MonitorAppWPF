using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsEntityLib.DataBasePersistances
{
    public class CreateCustomersClass : IDBPersistance
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

        public void AddChanges(object value)
        {
            if (value is Customer && value != null)
                _customers.Add(value as Customer);
        }

        public void SaveChanges()
        {
            try
            {
                using (PetsEContext _dbContext = new PetsEContext())
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
