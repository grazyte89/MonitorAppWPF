﻿using PetsEntityLib.DataBaseContext;
using PetsEntityLib.Entities;
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

        public bool DeleteItems(out string message)
        {
            message = string.Empty;
            try
            {
                if (_transactionsToDelete == null 
                    && _transactionsToDelete.Count <= 0)
                {
                    return false;
                }

                using (PetShopDBContext _dbcontext = new PetShopDBContext())
                {
                    _dbcontext.Transactions.RemoveRange(_transactionsToDelete);
                    _dbcontext.SaveChanges();
                    _transactionsToDelete.Clear();
                }

                message = "Deletion Successful";
                return true;
            }
            catch (Exception exception)
            {
                message = "Error";
                return false;
            }
        }
    }
}