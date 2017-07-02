using PetsEntityLib.DataBaseContext;
using PetsEntityLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsEntityLib.DataBaseExtractions
{
    public class RetrieveAnimals
    {
        public static IList<Animal> GetAllAnimals()
        {
            IList<Animal> animals = null;

            try
            {
                using (PetShopDBContext _datacontext = new PetShopDBContext())
                {
                    //animals = _datacontext.Set<Animal>()
                    animals = _datacontext.Animals
                                .ToList();
                }
            }
            catch (Exception exception)
            {
                //
            }

            return animals;
        }

        public static IList<Animal> GetAnimalsTop(int number)
        {
            IList<Animal> animals = null;

            try
            {
                using (PetShopDBContext _datacontext = new PetShopDBContext())
                {
                    animals = _datacontext.Animals
                                .Take(number)
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
