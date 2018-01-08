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

        /* In Entity-framework, an entity class with a one-to
         * -many relationship will have a collection which 
         * holds the child-entites.
         * 
         * Below are collections, which will hold the persisted 
         * child-entities which is associated with the persisted 
         * object of this entity class.
         * */

        [DataMember(Name = "SenderTransactions")]
        [InverseProperty("Sender")] // Sender is the foreign-key property in the Transaction class
        public virtual ICollection<Transaction> SenderTransactions { get; set; }

        [DataMember(Name = "ReceiverTransaction")]
        [InverseProperty("Receiver")] // Receiver is our foreign-key property in the Transaction class
        public virtual ICollection<Transaction> ReceiverTransactions { get; set; }

        /* There are cases where a table will have two or more 
         * foreigns keys pointing to the same primary key
         * e.g. multiple one-to-many relations.
         * 
         * In a normal situation (one foreign key), you would 
         * mark the foreign key property (either the int or 
         * refernce type) in the Transaction entity class with a 
         * foreign-key attribute.
         * 
         * But when two foreign keys properties in the same entity 
         * class, just adding an additional foreign-key attribute
         * will not work, and instead will throw an exception.
         * 
         * This is because with miltiple one-to-many relationships
         * entity creates four foreign-keys, instead of two.
         * 
         * E.g. Entity will create 4:
         * - Transaction_id
         * - Transaction_id1
         * - Receiver_id
         * - Sender_id
         * 
         * E.g. Corrent number of 2:
         * - Receiver_id
         * - Sender_id
         * 
         * Inverse-property attribute helps enyity figuare out that
         * the two properties are pointing to the same location
         * */

        /* If you're wondering, if the two collections contain the
         * same data, then the answer is No.
         * Because will figure out the sender-transaction collection 
         * should contain the list of senders a,d not the receiver-
         * transaction data, even though they are the same data-type.
         * */
    }
}
