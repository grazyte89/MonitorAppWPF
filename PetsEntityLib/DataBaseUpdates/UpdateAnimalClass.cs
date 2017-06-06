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
    public class UpdateAnimalClass : IDBUpdate
    {
        private Animal _currentAnimal;

        public UpdateAnimalClass(Animal animal)
        {
            _currentAnimal = animal;
        }

        public void SaveUpdate()
        {
            using (PetShopDBContext _context = new PetShopDBContext())
            {
                if (_currentAnimal != null)
                    return;
                _context.Entry(_currentAnimal).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}
