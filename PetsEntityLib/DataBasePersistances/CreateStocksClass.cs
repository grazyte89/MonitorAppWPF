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
    public class CreateStocksClass : IDBPersistance<Stock>
    {
        private IList<Stock> _stocks;

        public CreateStocksClass(IList<Stock> stocks)
        {
            if (stocks != null)
            {
                _stocks = stocks;
            }
            else
            {
                _stocks = new List<Stock>();
            }
        }

        public IList<Stock> Stocks
        {
            get { return _stocks; }
        }

        public void CreateStock(string name, double price, double itemPrice, double markup, double? targetSales = null)
        {
            double mark = (itemPrice / 100) * markup;
            double priceToMeetMark = itemPrice + mark;
            _stocks.Add(new Stock
            {
                NAME = name,
                PRICE = price,
                ITEM_PRICE = itemPrice,
                PRICE_TOMEET_MARK = priceToMeetMark,
                MARKUP = markup,
                TARGETSALEMK = targetSales
            });
        }

        public void AddItem(Stock value)
        {
            if (value != null)
            {
                _stocks.Add(value);
            }
        }

        public void SaveCreatedItems()
        {
            try
            {
                using (PetShopDBContext _dataContext = new PetShopDBContext())
                {
                    if (_stocks != null && _stocks.Count > 0)
                    {
                        _dataContext.Stocks.AddRange(_stocks);
                        _dataContext.SaveChanges();
                        _stocks.Clear();
                    }                    
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Problem encountered during persisting stock." +
                    "Message" + exception.Message);
            }
        }
    }
}
