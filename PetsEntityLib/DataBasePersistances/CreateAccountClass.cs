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
    public class CreateAccountClass : IDBPersistance<Account>
    {
        private IList<Account> _accounts;

        public CreateAccountClass(IList<Account> accounts)
        {
            if (accounts != null)
            {
                _accounts = accounts;
            }
            else
            {
                _accounts = new List<Account>();
            }
        }

        public IList<Account> Accounts
        {
            get
            {
                return _accounts;
            }
        }

        public void CreateAccount(int customerId, int balance = 0)
        {
            _accounts.Add(new Account()
            {
                CUSTOMER_ID = customerId,
                ACCOUNT_NUMBER = new Random().Next(1000000000, 2000000000),
                ACCOUNT_BALANCE = balance
            });
        }

        public void AddItem(Account value)
        {
            if (value != null)
            {
                _accounts.Add(value);
            }
        }

        public void SaveCreatedItems()
        {
            try
            {
                using (PetShopDBContext _dbcontext = new PetShopDBContext())
                {
                    if (_accounts != null && _accounts.Count > 0)
                    {
                        _dbcontext.Accounts.AddRange(_accounts);
                        _dbcontext.SaveChanges();
                        _accounts.Clear();
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Problem encountered during persisting account." +
                    "Message" + exception.Message);
            }
        }
    }
}
