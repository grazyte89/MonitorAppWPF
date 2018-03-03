using PetsEntityLib.DataBaseContext;
using PetsEntityLib.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            {
                _animalsToDelete = animalsToDelete;
            }
            else
            {
                _animalsToDelete = new List<Animal>();
            }
        }

        public DeleteAnimalClass(Animal animal)
        {
            _animalsToDelete = new List<Animal>();
            if (animal != null)
            {
                _animalsToDelete.Add(animal);
            }
        }

        public void AddItemForDeletion(Animal value)
        {
            if (value != null)
            {
                _animalsToDelete.Add(value);
            }
        }

        public bool DeleteItems(out string message)
        {
            message = string.Empty;
            try
            {
                using (PetShopDBContext _dbContext = new PetShopDBContext())
                {
                    if (_animalsToDelete != null && _animalsToDelete.Count > 0)
                    {
                        //_dbContext.Animals.RemoveRange(_animalsToDelete);
                        this.TagEntitiesAsDeleted(_dbContext);
                        _dbContext.SaveChanges();
                        _animalsToDelete.Clear();

                        message = "Animals deleted";
                        return true;
                    }
                    message = "Condition were not met, thus deletion function" +
                        " was not executed.";
                }
                
            }
            catch (Exception exception)
            {
                message = "Problem encountered during deleting animals." +
                    "Message" + exception.Message;
            }

            return false;
        }

        private void TagEntitiesAsDeleted(PetShopDBContext dbContext)
        {
            foreach (var item in _animalsToDelete)
            {
                dbContext.Entry(item).State = EntityState.Deleted;
                /* Our design pattern for this application was to
                 * have a sepration were all transactions create 
                 * a temporary db-context to communicate with the 
                 * database.
                 * Because of the sepertaion, we work in a disconneted
                 * way, which means that we have to manually set 
                 * the entity-state of the entity before we save 
                 * the object to the database.
                 * 
                 * If we do not specify an enity-state, then the 
                 * entity framework will throw an error.
                 * */
            }
        }
    }
}
