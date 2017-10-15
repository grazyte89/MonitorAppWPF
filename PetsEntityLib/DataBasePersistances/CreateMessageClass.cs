using PetsEntityLib.DataBaseContext;
using PetsEntityLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsEntityLib.DataBasePersistances
{
    public class CreateMessageClass : IDBPersistance<Message>
    {
        private IList<Message> _messages;

        public CreateMessageClass(IList<Message> message)
        {
            if (message != null)
            {
                _messages = message;
            }
            else
            {
                _messages = new List<Message>();
            }
        }

        public IList<Message> Messages
        {
            get
            {
                return _messages;
            }
        }

        public CreateMessageClass(string sender, string receiver, string messageHead, string text, DateTime sendByDate, int senderId)
        {
            _messages.Add(new Message
            {
                SENDER = sender,
                RECEIVER = receiver,
                MESSAGE_HEAD = messageHead,
                TEXT = text,
                SEND_BY_DATE = sendByDate,
                SENDER_ID = senderId
            });
        }

        public void AddItem(Message value)
        {
            if (value != null)
            {
                _messages.Add(value);
            }
        }

        public void SaveCreatedItems()
        {
            try
            {
                using (PetShopDBContext _dataContext = new PetShopDBContext())
                {
                    if (_messages != null && _messages.Count > 0)
                    {
                        _dataContext.Messages.AddRange(_messages);
                        _dataContext.SaveChanges();
                        _messages.Clear();
                    }
                }
            }
            catch (Exception exception)
            {
                System.Windows.Forms.MessageBox.Show("Problem encountered during persisting Message." +
                   "Message" + exception.Message);
            }
        }
    }
}
