using PetsEntityLib.DataBaseContext;
using PetsEntityLib.Entities;
using PetsEntityLib.EntityExtensions;
using PetsEntityLib.PetsExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetsEntityLib.DataBaseDeletions
{
    public class DeleteStockClass : IDBDeletion<Stock>
    {
        private IList<Stock> _stocksToDelete;

        public DeleteStockClass(IList<Stock> stocksToDelete)
        {
            if (stocksToDelete != null)
            {
                _stocksToDelete = stocksToDelete;
            }
            else
            {
                _stocksToDelete = new List<Stock>();
            }
        }

        public DeleteStockClass(Stock stock)
        {
            _stocksToDelete = new List<Stock>();
            if (stock != null)
            {
                _stocksToDelete.Add(stock);
            }
        }

        public void AddItemForDeletion(Stock value)
        {
            if (value != null)
            {
                _stocksToDelete.Add(value);
            }
        }

        public void DeleteItems()
        {
            if (_stocksToDelete == null || _stocksToDelete.Count <= 0)
            {
                var reason = _stocksToDelete == null
                        ? "null" : "equal or less than zero";
                var message = string.Format("Deletion could not be executed " +
                        "because to the internal list being {0}", reason);
                throw new PetsEntityException(message);
            }

            try
            {
                using (PetShopDBContext _dbContext = new PetShopDBContext())
                {
                    //_dbContext.Stocks.RemoveRange(_stocksToDelete);
                    _dbContext.TagEntitiesAsDeleted<Stock>(_stocksToDelete);
                    _dbContext.SaveChanges();
                    _stocksToDelete.Clear();
                }
            }
            catch (Exception exception)
            {
                throw;
            }
        }
    }
}