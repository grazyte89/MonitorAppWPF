using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PetsEntityLib.Entities
{
    public class Account : IEntityDaBase
    {
        public Account()
        {
            Transactions = new List<Transaction>();
        }

        public int ID { get; set; }

        public int ACCOUNT_NUMBER { get; set; }

        public int CUSTOMER_ID { get; set; }

        public int ACCOUNT_BALANCE { get; set; }

        [ForeignKey("CUSTOMER_ID")]
        public virtual Customer Customer { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}
