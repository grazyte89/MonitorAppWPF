using PetsEntityLib.DataBaseContext;
using PetsEntityLib.Entities;
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

        public bool DeleteItems(out string message)
        {
            message = string.Empty;
            try
            {
                using (PetShopDBContext _dbContext = new PetShopDBContext())
                {
                    if (_stocksToDelete != null && _stocksToDelete.Count > 0)
                    {
                        _dbContext.Stocks.RemoveRange(_stocksToDelete);
                        _dbContext.SaveChanges();
                        _stocksToDelete.Clear();
                    }
                }
                message = "Deletion Successful";
                return true;
            }
            catch (Exception exception)
            {
                message = "Problem encountered during deleting stocks." +
                    "Message" + exception.Message;
                return false;
            }
        }
    }
}