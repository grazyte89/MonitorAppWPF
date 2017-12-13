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
            ReceiverTransactions = new List<Transaction>();
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
        public virtual ICollection<Transaction> ReceiverTransactions { get; set; }

        /* There may cases where a table will have two or more 
         * foreigns keys pointing to the same primary key.
         * In a normal situation (one foreign key), you would 
         * mark the foreign property (either the int or refernce type) 
         * in the Transaction entity class with a foreign key attribute.
         * But applying two foreign keys two properties in the same causes
         * a problem.
         * */
    }
}
