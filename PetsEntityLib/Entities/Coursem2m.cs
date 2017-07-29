using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsEntityLib.Entities
{
    public class Coursem2m : IEntityDaBase
    {
        public Coursem2m()
        {
            this.Customers = new HashSet<Customer>();
        }

        public int ID { get; set; }
        public string NAME_MM { get; set; }
        public string SUBJECT_TYPE_MM { get; set; }

        public ICollection<Customer> Customers { get; set; }
    }
}
