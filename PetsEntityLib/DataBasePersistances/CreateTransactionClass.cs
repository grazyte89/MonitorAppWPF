using PetsEntityLib.DataBaseContext;
using PetsEntityLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetsEntityLib.DataBasePersistances
{
    public class CreateTransactionClass : IDBPersistance<Transaction>
    {
        private IList<Transaction> _transactions;

        public CreateTransactionClass(IList<Transaction> transactions)
        {
            if (transactions != null)
            {
                _transactions = transactions;
            }
            else
            {
                _transactions = new List<Transaction>();
            }
        }

        public IList<Transaction> Transactions
        {
            get
            {
                return _transactions;
            }
        }

        public void CreateTransaction(int senderId, int receiverId, int amount)
        {
            _transactions.Add(new Transaction()
            {
                SENDER_ACCOUNT_ID = senderId,
                RECEIVER_ACCOUNT_ID = receiverId,
                AMOUNT_SENT = amount,
                TRANSACTION_TIME_LOG = DateTime.Now
            });
        }

        public void AddItem(Transaction value)
        {
            if (value != null)
            {
                _transactions.Add(value);
            }
        }

        public void SaveCreatedItems()
        {
            try
            {
                using (PetShopDBContext _dbcontext = new PetShopDBContext())
                {
                    if (_transactions != null && _transactions.Count > 0)
                    {
                        _dbcontext.Transactions.AddRange(_transactions);
                        _dbcontext.SaveChanges();
                        _transactions.Clear();
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Problem encountered during persisting transaction." +
                    "Message" + exception.Message);
            }
        }
    }
}