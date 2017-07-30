using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsEntityLib.Entities
{
    public class Course : IEntityDaBase
    {
        public Course()
        {
            this.Customers = new HashSet<JoinCustomerCourse>();
        }

        public int ID { get; set; }
        public string NAME { get; set; }
        public string SUBJECT_TYPE { get; set; }

        public ICollection<JoinCustomerCourse> Customers { get; set; } 
    }
}
