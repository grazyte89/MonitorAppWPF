using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsEntityLib.Entities
{
    public class Transaction : IEntityDaBase
    {
        //[Key, Column(Order = 0)]
        public int ID { get; set; }

        //[Key, Column(Order = 1), ForeignKey("Sender")]
        public int SENDER_ACCOUNT_ID { get; set; }

        //[Key, Column(Order = 2), ForeignKey("Receiver")]
        public int RECEIVER_ACCOUNT_ID { get; set; }

        public int AMOUNT_SENT { get; set; }

        public DateTime TRANSACTION_TIME_LOG { get; set; }

        [ForeignKey("SENDER_ACCOUNT_ID")]
        public virtual Account Sender { get; set; }

        [ForeignKey("RECEIVER_ACCOUNT_ID")]
        public virtual Account Receiver { get; set; }
    }
}
