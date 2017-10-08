using PetsEntityLib.DataBaseContext;
using PetsEntityLib.Entities;
using System;
using System.Collections.Generic;
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
