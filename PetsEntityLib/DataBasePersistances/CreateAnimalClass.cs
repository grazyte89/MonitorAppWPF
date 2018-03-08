using PetsEntityLib.DataBaseContext;
using PetsEntityLib.Entities;
using PetsEntityLib.PetsExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetsEntityLib.DataBasePersistances
{
    public class CreateAnimalClass : IDBPersistance<Animal>
    {
        private IList<Animal> _animals;

        public CreateAnimalClass(IList<Animal> animals)
        {
            if (animals != null)
            {
                _animals = animals;
            }
            else
            {
                _animals = new List<Animal>();
            }
        }

        public IList<Animal> Animals
        {
            get
            {
                return _animals;
            }
        }

        public void CreateAnimal(string name, int age, string gender, string type, DateTime? vacination = null, DateTime? checkup = null,
            string status = null)
        {
            _animals.Add(new Animal
            {
                NAME = name,
                AGE = age,
                GENDER = gender,
                TYPE = type,
                VACINATION = vacination,
                CHECKUP = checkup,
                STATUS = status
            });
        }

        public void AddItem(Animal value)
        {
            if (value != null)
            {
                _animals.Add(value);
            }
        }

        public void SaveCreatedItems()
        {
            if (_animals == null || _animals.Count <= 0)
            {
                var reason = _animals == null
                        ? "null" : "equal or less than zero";
                var message = string.Format("Saving business logic was not executed, " +
                        "this was due to the internal list being {0}", reason);
                throw new PetsEntityException(message);
            }

            try
            {
                using (PetShopDBContext _dataContext = new PetShopDBContext())
                {
                    _dataContext.Animals.AddRange(_animals);
                    _dataContext.SaveChanges();
                    _animals.Clear();
                }
            }
            catch (Exception exception)
            {
                throw;
            }
        }
    }
}
