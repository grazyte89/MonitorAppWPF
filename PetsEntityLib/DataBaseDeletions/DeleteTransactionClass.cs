using PetsEntityLib.DataBaseContext;
using PetsEntityLib.Entities;
using PetsEntityLib.EntityExtensions;
using PetsEntityLib.PetsExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsEntityLib.DataBaseDeletions
{
    public class DeleteTransactionClass : IDBDeletion<Transaction>
    {
        private IList<Transaction> _transactionsToDelete;

        public DeleteTransactionClass(IList<Transaction> transactionsToDelete)
        {
            if (transactionsToDelete != null)
            {
                _transactionsToDelete = transactionsToDelete;
            }
            else
            {
                _transactionsToDelete = new List<Transaction>();
            }
        }

        public void AddItemForDeletion(Transaction value)
        {
            if (value != null)
            {
                _transactionsToDelete.Add(value);
            }
        }

        public void DeleteItems()
        {
            if (_transactionsToDelete == null && _transactionsToDelete.Count <= 0)
            {
                var reason = _transactionsToDelete == null
                        ? "null" : "equal or less than zero";
                var message = string.Format("Deletion could not be executed " +
                        "because to the internal list being {0}", reason);
                throw new PetsEntityException(message);
            }

            try
            {
                using (PetShopDBContext _dbcontext = new PetShopDBContext())
                {
                    //_dbcontext.Transactions.RemoveRange(_transactionsToDelete);
                    _dbcontext.TagEntitiesAsDeleted<Transaction>(_transactionsToDelete);
                    _dbcontext.SaveChanges();
                    _transactionsToDelete.Clear();
                }
            }
            catch (Exception exception)
            {
                // logging
                throw;
            }
        }
    }
}