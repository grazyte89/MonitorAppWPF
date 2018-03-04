using PetsEntityLib.DataBaseContext;
using PetsEntityLib.Entities;
using PetsEntityLib.PetsExceptions;
using PetsEntityLib.EntityExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsEntityLib.DataBaseDeletions
{
    public class DeleteMessageClass : IDBDeletion<Message>
    {
        private IList<Message> _messagesToDelete;

        public DeleteMessageClass(IList<Message> messagesToDelete)
        {
            if (messagesToDelete != null)
            {
                _messagesToDelete = messagesToDelete;
            }
            else
            {
                _messagesToDelete = new List<Message>();
            }
        }

        public DeleteMessageClass(Message message)
        {
            _messagesToDelete = new List<Message>();
            if (message != null)
            {
                _messagesToDelete.Add(message);
            }
        }

        public void AddItemForDeletion(Message value)
        {
            if (value != null)
            {
                _messagesToDelete.Add(value);
            }
        }

        public void DeleteItems()
        {
            if (_messagesToDelete == null || _messagesToDelete.Count <= 0)
            {
                var reason = _messagesToDelete == null
                        ? "null" : "equal or less than zero";
                var message = string.Format("Deletion could not be executed " +
                        "because to the internal list being {0}", reason);
                throw new PetsEntityException(message);
            }

            try
            {
                using (PetShopDBContext _dbContext = new PetShopDBContext())
                {
                    //_dbContext.Messages.RemoveRange(_messagesToDelete);
                    _dbContext.TagEntitiesAsDeleted<Message>(_messagesToDelete);
                    _dbContext.SaveChanges();
                    _messagesToDelete.Clear();
                }
            }
            catch (Exception exception)
            {
                // logging
                throw;
            }
        }
    }
}
