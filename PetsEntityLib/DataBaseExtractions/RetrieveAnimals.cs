using PetsEntityLib.DataBaseContext;
using PetsEntityLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsEntityLib.DataBaseExtractions
{
    public static class RetrieveAnimals
    {
        public static IList<Animal> GetAllAnimals()
        {
            IList<Animal> animals = null;

            try
            {
                using (PetShopDBContext _datacontext = new PetShopDBContext())
                {
                    //animals = _datacontext.Animals
                    animals = _datacontext.Set<Animal>()
                                .Take(100)
                                .ToList();
                }
            }
            catch (Exception exception)
            {
                //
            }

            return animals;
        }
    }
}
