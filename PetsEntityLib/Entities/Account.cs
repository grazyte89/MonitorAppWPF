using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PetsEntityLib.Entities
{
    [DataContract(Name = "Account")]
    public class Account : IEntityDaBase
    {
        public Account()
        {
            SenderTransactions = new List<Transaction>();
            ReceiverTransaction = new List<Transaction>();
        }

        [DataMember(Name = "ID")]
        public int ID { get; set; }

        [DataMember(Name = "ACCOUNT_NUMBER")]
        public int ACCOUNT_NUMBER { get; set; }

        [DataMember(Name = "CUSTOMER_ID")]
        public int CUSTOMER_ID { get; set; }

        [DataMember(Name = "ACCOUNT_BALANCE")]
        public int ACCOUNT_BALANCE { get; set; }

        [DataMember(Name = "Customer")]
        [ForeignKey("CUSTOMER_ID")]
        public virtual Customer Customer { get; set; }

        [DataMember(Name = "SenderTransactions")]
        [InverseProperty("Sender")]
        public virtual ICollection<Transaction> SenderTransactions { get; set; }

        [DataMember(Name = "ReceiverTransaction")]
        [InverseProperty("Receiver")]
        public virtual ICollection<Transaction> ReceiverTransaction { get; set; }
    }
}
