using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PetsEntityLib.Entities
{
    [Serializable]
    [DataContract(Name = "Course")]
    public class Course : IEntityDaBase
    {
        public Course()
        {
            this.Customers = new HashSet<JoinCustomerCourse>();
        }

        [DataMember(Name = "ID")]
        public int ID { get; set; }

        [DataMember(Name = "NAME")]
        public string NAME { get; set; }

        [DataMember(Name = "SUBJECT_TYPE")]
        public string SUBJECT_TYPE { get; set; }

        [DataMember(Name = "Customers")]
        public ICollection<JoinCustomerCourse> Customers { get; set; } 
    }
}
