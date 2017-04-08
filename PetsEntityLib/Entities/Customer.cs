using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PetsEntityLib.Entities
{
    [DataContract(Name = "Customer")]
    public class Customer : IEntityDaBase
    {
        public Customer()
        {
            this.AnimalSolds = new HashSet<AnimalSold>();
        }

        [DataMember(Name = "ID")]
        public int ID { get; set; }
        [DataMember(Name = "FIRSTNAME")]
        public string FIRSTNAME { get; set; }
        [DataMember(Name = "LASTNAME")]
        public string LASTNAME { get; set; }
        [DataMember(Name = "AGE")]
        public int AGE { get; set; }
        [DataMember(Name = "ADDRESS")]
        public string ADDRESS { get; set; }

        [DataMember(Name = "ANIMALSOLD")]
        public virtual ICollection<AnimalSold> AnimalSolds { get; set; }
    }
}
