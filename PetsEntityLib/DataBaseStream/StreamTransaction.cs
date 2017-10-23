using PetsEntityLib.DataBaseUpdates;
using PetsEntityLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsEntityLib.DataBaseStream
{
    public class StreamTransaction : IDBStream
    {
        private Account _senderAccount;
        private Account _receiverAccount;
        private int _transferAmount;

        public StreamTransaction(Account senderAccount, Account receiverAccount, int transferAmount)
        {
            _senderAccount = senderAccount;
            _receiverAccount = receiverAccount;
            _transferAmount = transferAmount;
        }

        public void ExecuteStream()
        {
            if (_senderAccount == null || _senderAccount.ID == 0
                || _receiverAccount == null || _receiverAccount.ID == 0
                || _transferAmount == 0)
            {
                // Condiition are not correct transactions to proceed;
                return;
            }

            var updateSender = new UpdateAccountClass(_senderAccount);
        }
    }
}
