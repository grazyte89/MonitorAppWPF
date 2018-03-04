using PetsEntityLib.DataBaseContext;
using PetsEntityLib.Entities;
using PetsEntityLib.EntityExtensions;
using PetsEntityLib.PetsExceptions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            if (_accountsToDelete == null || _accountsToDelete.Count <= 0)
            {
                var reason = _accountsToDelete == null
                        ? "null" : "equal or less than zero";
                var message = string.Format("Deletion could not be executed " +
                        "because to the internal list being {0}", reason);
                throw new PetsEntityException(message);
            }

            try
            {
                using (PetShopDBContext _dbcontext = new PetShopDBContext())
                {
                    //_dbcontext.Accounts.AddRange(_accountsToDelete);
                    _dbcontext.TagEntitiesAsDeleted<Account>(_accountsToDelete);
                    _dbcontext.SaveChanges();
                    _accountsToDelete.Clear();
                }
            }
            catch (Exception exception)
            {
                // add logging here
                throw;
            }
        }

        /*private void TagEntitiesAsDeleted(PetShopDBContext dbContext)
        {
            foreach (var item in _accountsToDelete)
            {
                dbContext.Entry(item).State = EntityState.Deleted;
            }
        }*/
    }
}
