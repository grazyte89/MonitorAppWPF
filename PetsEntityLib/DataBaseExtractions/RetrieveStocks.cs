using PetsEntityLib.DataBaseContext;
using PetsEntityLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsEntityLib.DataBaseExtractions
{
    public class RetrieveStocks
    {
        public static IList<Stock> GetAllStocks()
        {
            IList<Stock> customers = null;

            try
            {
                using (PetShopDBContext _dataContext = new PetShopDBContext())
                {
                    customers = _dataContext.Stocks
                                  .ToList();
                }
            }
            catch (Exception exception)
            {
                // logging here
            }

            return customers;
        }
    }
}
