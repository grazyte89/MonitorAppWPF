using PetsEntityLib.DataBaseContext;
using PetsEntityLib.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetsEntityLib.DataBaseUpdates
{
    public class UpdateAccountClass : IDBUpdate
    {
        private Account _currentAccount;

        public UpdateAccountClass(Account currentAccount)
        {
            _currentAccount = currentAccount;
        }

        public void SaveUpdate()
        {
            try
            {
                if (_currentAccount == null)
                {
                    return;
                }

                using (PetShopDBContext _dbcontext = new PetShopDBContext())
                {
                    _dbcontext.Entry(_currentAccount).State = EntityState.Modified;
                    _dbcontext.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("");
            }
        }
    }
}
