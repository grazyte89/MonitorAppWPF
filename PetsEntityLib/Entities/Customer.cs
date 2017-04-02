using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsEntityLib.Entities
{
    public class Customer : IEntityBase
    {
        public Customer()
        {
            this.AnimalSolds = new HashSet<AnimalSold>();
        }

        public int ID { get; set; }
        public string FIRSTNAME { get; set; }
        public string LASTNAME { get; set; }
        public int AGE { get; set; }
        public string ADDRESS { get; set; }

        public virtual ICollection<AnimalSold> AnimalSolds { get; set; }
    }
}
