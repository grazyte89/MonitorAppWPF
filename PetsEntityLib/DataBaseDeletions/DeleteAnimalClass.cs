using PetsEntityLib.DataBaseContext;
using PetsEntityLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetsEntityLib.DataBaseDeletions
{
    public class DeleteAnimalClass : IDBDeletion<Animal>
    {
        private IList<Animal> _animalsToDelete;

        public DeleteAnimalClass(IList<Animal> animalsToDelete)
        {
            if (animalsToDelete != null)
                _animalsToDelete = animalsToDelete;
            else
                _animalsToDelete = new List<Animal>();
        }

        public DeleteAnimalClass(Animal animal)
        {
            _animalsToDelete = new List<Animal>();
            if (animal != null)
                _animalsToDelete.Add(animal);
        }

        public void AddItemForDeletion(Animal value)
        {
            if (value != null)
                _animalsToDelete.Add(value);
        }

        public void DeleteItems()
        {
            try
            {
                using (PetShopDBContext _dbContext = new PetShopDBContext())
                {
                    if (_animalsToDelete != null && _animalsToDelete.Count > 0)
                    {
                        _dbContext.Animals.RemoveRange(_animalsToDelete);
                        _dbContext.SaveChanges();
                        _animalsToDelete.Clear();
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Problem encountered during deleting animals." +
                    "Message" + exception.Message);
            }
        }
    }
}
