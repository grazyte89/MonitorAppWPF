using PetsEntityLib.DataBaseContext;
using PetsEntityLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsEntityLib.DataBaseDeletions
{
    public class DeleteAccountClass : IDBDeletion<Account>
    {
        private IList<Account> _accountsToDelete;

        public DeleteAccountClass(IList<Account> accountsToDelete)
        {
            if (accountsToDelete != null)
            {
                _accountsToDelete = accountsToDelete;
            }
            else
            {
                _accountsToDelete = new List<Account>();
            }
        }

        public void AddItemForDeletion(Account value)
        {
            if (value != null)
            {
                _accountsToDelete.Add(value);
            }
        }

        public void DeleteItems()
        {
            try
            {
                if (_accountsToDelete == null && _accountsToDelete.Count <= 0)
                {
                    return;
                }

                using (PetShopDBContext _dbcontext = new PetShopDBContext())
                {
                    _dbcontext.Accounts.AddRange(_accountsToDelete);
                    _dbcontext.SaveChanges();
                    _accountsToDelete.Clear();
                }
            }
            catch (Exception exception)
            {
                // add logging here
            }
        }
    }
}
