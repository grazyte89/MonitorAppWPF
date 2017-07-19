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
    public class CreateAnimalsSoldClass : IDBPersistance<AnimalSold>
    {
        private IList<AnimalSold> _animalSoldList;

        public CreateAnimalsSoldClass(IList<AnimalSold> animalSoldList)
        {
            if (animalSoldList != null)
                _animalSoldList = animalSoldList;
            else
                _animalSoldList = new List<AnimalSold>();
        }

        public IList<AnimalSold> AnimalsSold
        {
            get { return _animalSoldList; }
        }

        public void Create(int animalId, int customerId)
        {
            _animalSoldList.Add(new AnimalSold
            {
                ANIMAL_ID = animalId,
                OWNER_ID = customerId
            });
        }

        public void AddItem(AnimalSold value)
        {
            if (value != null)
                _animalSoldList.Add(value);
        }

        public void SaveCreatedItems()
        {
            try
            {
                using (PetShopDBContext _dataContext = new PetShopDBContext())
                {
                    if (_animalSoldList != null && _animalSoldList.Count > 0)
                    {
                        _dataContext.AnimalSolds.AddRange(_animalSoldList);
                        _dataContext.SaveChanges();
                        _animalSoldList.Clear();
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Problem encountered during persisting sold animal." +
                    "Message" + exception.Message);
            }
        }
    }
}
