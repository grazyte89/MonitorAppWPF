using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PetsEntityLib.Entities
{
    [DataContract(Name = "Transaction")]
    public class Transaction : IEntityDaBase
    {
        //[Key, Column(Order = 0)]
        [DataMember(Name = "ID")]
        public int ID { get; set; }

        //[Key, Column(Order = 1), ForeignKey("Sender")]
        [DataMember(Name = "SENDER_ACCOUNT_ID")]
        public int SENDER_ACCOUNT_ID { get; set; }

        //[Key, Column(Order = 2), ForeignKey("Receiver")]
        [DataMember(Name = "RECEIVER_ACCOUNT_ID")]
        public int RECEIVER_ACCOUNT_ID { get; set; }

        [DataMember(Name = "AMOUNT_SENT")]
        public int AMOUNT_SENT { get; set; }

        [DataMember(Name = "TRANSACTION_TIME_LOG")]
        public DateTime TRANSACTION_TIME_LOG { get; set; }

        [DataMember(Name = "Sender")]
        [ForeignKey("SENDER_ACCOUNT_ID")]
        public virtual Account Sender { get; set; }

        [DataMember(Name = "Receiver")]
        [ForeignKey("RECEIVER_ACCOUNT_ID")]
        public virtual Account Receiver { get; set; }
    }
}
