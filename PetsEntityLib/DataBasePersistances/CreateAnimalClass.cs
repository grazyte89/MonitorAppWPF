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
            try
            {
                using (PetShopDBContext _dataContext = new PetShopDBContext())
                {
                    if (_animals != null && _animals.Count > 0)
                    {
                        //_dataContext.Set<Animal>().AddRange(_animals);
                        _dataContext.Animals.AddRange(_animals);
                        _dataContext.SaveChanges();
                        _animals.Clear();
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Problem encountered during persisting animal." +
                    "Message" + exception.Message);
            }
        }
    }
}
