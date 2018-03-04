using PetsEntityLib.DataBaseContext;
using PetsEntityLib.Entities;
using PetsEntityLib.PetsExceptions;
using PetsEntityLib.EntityExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetsEntityLib.DataBaseDeletions
{
    public class DeleteCustomerClass : IDBDeletion<Customer>
    {
        private IList<Customer> _customersToDelete;

        public DeleteCustomerClass(IList<Customer> customersToDelete)
        {
            if (customersToDelete != null)
            {
                _customersToDelete = customersToDelete;
            }
            else
            {
                _customersToDelete = new List<Customer>();
            }
        }

        public DeleteCustomerClass(Customer customer)
        {
            _customersToDelete = new List<Customer>();
            if (customer != null)
            {
                _customersToDelete.Add(customer);
            }
        }

        public void AddItemForDeletion(Customer value)
        {
            if (value != null)
            {
                _customersToDelete.Add(value);
            }
        }

        public void DeleteItems()
        {
            if (_customersToDelete == null || _customersToDelete.Count <= 0)
            {
                var reason = _customersToDelete == null
                        ? "null" : "equal or less than zero";
                var message = string.Format("Deletion could not be executed " +
                        "because to the internal list being {0}", reason);
                throw new PetsEntityException(message);
            }

            try
            {
                using (PetShopDBContext _dbContext = new PetShopDBContext())
                {
                    //_dbContext.Customers.RemoveRange(_customersToDelete);
                    _dbContext.TagEntitiesAsDeleted<Customer>(_customersToDelete);
                    _dbContext.SaveChanges();
                    _customersToDelete.Clear();
                }
            }
            catch (Exception exception)
            {
                // logging here
                throw;
            }
        }
    }
}
