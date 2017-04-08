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
        private List<Stock> _stocks;

        public CreateStocksClass(List<Stock> stocks)
        {
            if (stocks != null)
                _stocks = stocks;
            else
                _stocks = new List<Stock>();
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

        public void AddChanges(Stock value)
        {
            if (value != null)
                _stocks.Add(value);
        }

        public void SaveChanges()
        {
            try
            {
                using (PetShopDBContext _dataContext = new PetShopDBContext())
                {
                    _dataContext.Stocks.AddRange(_stocks);
                    _dataContext.SaveChanges();
                }
                _stocks.Clear();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error encountered when persisting stocks. Message: " 
                    + exception.Message);
            }
        }
    }
}
