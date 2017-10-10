using PetsEntityLib.DataBaseContext;
using PetsEntityLib.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsEntityLib.DataBaseExtractions
{
    public class RetrieveAnimalsSold
    {
        public static IList<AnimalSold> GetAllAnimalsSold()
        {
            IList<AnimalSold> animalSolds = null;

            try
            {
                using (PetShopDBContext _dataContext = new PetShopDBContext())
                {
                    animalSolds = _dataContext.AnimalSolds
                                    .Include(x => x.Customer)
                                    .ToList();
                }
            }
            catch (Exception exception)
            {
                // logging here
            }

            return animalSolds;
        }
    }
}
