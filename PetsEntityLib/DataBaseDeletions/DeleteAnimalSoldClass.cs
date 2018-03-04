using PetsEntityLib.DataBaseContext;
using PetsEntityLib.Entities;
using PetsEntityLib.EntityExtensions;
using PetsEntityLib.PetsExceptions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public void DeleteItems()
        {
            if (_animalSoldsToDelete == null || _animalSoldsToDelete.Count <= 0)
            {
                var reason = _animalSoldsToDelete == null
                        ? "null" : "equal or less than zero";
                var message = string.Format("Deletion could not be executed " +
                        "because to the internal list being {0}", reason);
                throw new PetsEntityException(message);
            }

            try
            {
                using (PetShopDBContext _dbContext = new PetShopDBContext())
                {
                    //_dbContext.AnimalSolds.RemoveRange(_animalSoldsToDelete);
                    _dbContext.TagEntitiesAsDeleted<AnimalSold>(_animalSoldsToDelete);
                    _dbContext.SaveChanges();
                    _animalSoldsToDelete.Clear();
                }
            }
            catch (Exception exception)
            {
                // logging here
                throw;
            }
        }

        /*private void TagEntitiesAsDeleted(PetShopDBContext dbContext)
        {
            foreach (var item in _animalSoldsToDelete)
            {
                dbContext.Entry(item).State = EntityState.Deleted;
            }
        }*/
    }
}
