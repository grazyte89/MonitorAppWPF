using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsEntityLib.Entities
{
    public class Transaction : IEntityDaBase
    {
        public int ID { get; set; }

        public int SENDER_ACCOUNT_ID { get; set; }

        public int RECEIVER_ACCOUNT_ID { get; set; }

        public int AMMOUNT_SENT { get; set; }

        public DateTime TRANSACTION_TIME_LOG { get; set; }

        [ForeignKey("SENDER_ACCOUNT_ID")]
        public Account Sender { get; set; }

        [ForeignKey("RECEIVER_ACCOUNT_ID")]
        public Account Receiver { get; set; }
    }
}
