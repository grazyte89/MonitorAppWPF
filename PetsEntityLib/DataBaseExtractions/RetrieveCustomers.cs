using PetsEntityLib.DataBaseContext;
using PetsEntityLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsEntityLib.DataBaseExtractions
{
    public static class RetrieveCustomers
    {
        public static IList<Customer> GetAllCustomers()
        {
            IList<Customer> customers = null;

            try
            {
                using (PetShopDBContext _dataContext = new PetShopDBContext())
                {
                    customers = _dataContext.Customers
                                  .Take(100)
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
