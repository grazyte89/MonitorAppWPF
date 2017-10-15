using PetsEntityLib.DataBaseContext;
using PetsEntityLib.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsEntityLib.DataBaseUpdates
{
    public class UpdateStockClass : IDBUpdate
    {
        private Stock _currentStock;

        public UpdateStockClass(Stock stock)
        {
            this._currentStock = stock;
        }

        public void SaveUpdate()
        {
            using (PetShopDBContext _dbcontext = new PetShopDBContext())
            {
                if (_currentStock == null)
                {
                    return;
                }
                _dbcontext.Entry(_currentStock).State = EntityState.Modified;
                _dbcontext.SaveChanges();
            }
        }
    }
}
