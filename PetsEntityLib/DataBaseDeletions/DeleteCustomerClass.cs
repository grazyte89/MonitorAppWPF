using PetsEntityLib.DataBaseContext;
using PetsEntityLib.Entities;
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
            try
            {
                using (PetShopDBContext _dbContext = new PetShopDBContext())
                {
                    if (_customersToDelete != null && _customersToDelete.Count > 0)
                    {
                        _dbContext.Customers.RemoveRange(_customersToDelete);
                        _dbContext.SaveChanges();
                        _customersToDelete.Clear();
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Problem encountered during deleting customers." +
                    "Message" + exception.Message);
            }
        }
    }
}
