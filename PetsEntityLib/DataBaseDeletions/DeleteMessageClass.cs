using PetsEntityLib.DataBaseContext;
using PetsEntityLib.Entities;
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
            try
            {
                using (PetShopDBContext _dbContext = new PetShopDBContext())
                {
                    if (_messagesToDelete != null && _messagesToDelete.Count > 0)
                    {
                        _dbContext.Messages.RemoveRange(_messagesToDelete);
                        _dbContext.SaveChanges();
                        _messagesToDelete.Clear();
                    }
                }
            }
            catch (Exception exception)
            {
                System.Windows.Forms.MessageBox.Show("Problem encountered during deleting customers." +
                    "Message" + exception.Message);
            }
        }
    }
}
