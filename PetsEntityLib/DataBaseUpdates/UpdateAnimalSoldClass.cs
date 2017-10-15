using PetsEntityLib.DataBaseContext;
using PetsEntityLib.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsEntityLib.DataBaseUpdates
{
    public class UpdateAnimalSoldClass : IDBUpdate
    {
        private AnimalSold _currentAnimalSold;

        public UpdateAnimalSoldClass(AnimalSold animalSold)
        {
            _currentAnimalSold = animalSold;
        }

        public void SaveUpdate()
        {
            using (PetShopDBContext _dbcontext = new PetShopDBContext())
            {
                if (_currentAnimalSold == null)
                {
                    return;
                }
                _dbcontext.Entry(_currentAnimalSold).State = EntityState.Modified;
                _dbcontext.SaveChanges();
            }
        }
    }
}
