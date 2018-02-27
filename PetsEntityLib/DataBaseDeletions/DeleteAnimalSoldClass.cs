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
    public class DeleteAnimalSoldClass : IDBDeletion<AnimalSold>
    {
        private IList<AnimalSold> _animalSoldsToDelete;

        public DeleteAnimalSoldClass(IList<AnimalSold> animalSoldsToDelete)
        {
            if (animalSoldsToDelete != null)
            {
                _animalSoldsToDelete = animalSoldsToDelete;
            }
            else
            {
                _animalSoldsToDelete = new List<AnimalSold>();
            }
        }

        public DeleteAnimalSoldClass(AnimalSold animalSold)
        {
            _animalSoldsToDelete = new List<AnimalSold>();
            if (animalSold != null)
            {
                _animalSoldsToDelete.Add(animalSold);
            }
        }

        public void AddItemForDeletion(AnimalSold value)
        {
            if (value != null)
            {
                _animalSoldsToDelete.Add(value);
            }
        }

        public bool DeleteItems(out string message)
        {
            message = string.Empty;
            try
            {
                using (PetShopDBContext _dbContext = new PetShopDBContext())
                {
                    if (_animalSoldsToDelete != null && _animalSoldsToDelete.Count > 0)
                    {
                        _dbContext.AnimalSolds.RemoveRange(_animalSoldsToDelete);
                        _dbContext.SaveChanges();
                        _animalSoldsToDelete.Clear();
                    }
                }
                message = "Deletion Successful";
                return true;
            }
            catch (Exception exception)
            {
                message = "Problem encountered during deleting animalsold." +
                    "Message" + exception.Message;
                return false;
            }
        }
    }
}
