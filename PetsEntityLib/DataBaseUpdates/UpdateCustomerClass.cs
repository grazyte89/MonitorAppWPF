using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetsEntityLib.Entities;
using PetsEntityLib.DataBaseContext;
using System.Data.Entity;

namespace PetsEntityLib.DataBaseUpdates
{
    public class UpdateCustomerClass : IDBUpdate
    {
        private Customer _currentCustomer;

        public UpdateCustomerClass(Customer customer)
        {
            this._currentCustomer = customer;
        }

        public void SaveUpdate()
        {
            using (PetShopDBContext _dbcontext = new PetShopDBContext())
            {
                if (_currentCustomer == null)
                    return;
                _dbcontext.Entry(_currentCustomer).State = EntityState.Modified;
                _dbcontext.SaveChanges();
            }
        }
    }
}
