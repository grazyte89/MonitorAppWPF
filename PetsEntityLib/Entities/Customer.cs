using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace PetsEntityLib.Entities
{
    [Serializable]
    [DataContract(Name = "Customer")]
    public partial class Customer : IEntityDaBase
    {
        public Customer()
        {
            this.AnimalSolds = new HashSet<AnimalSold>();
            this.Messages = new HashSet<Message>();
            this.Courses = new HashSet<JoinCustomerCourse>();
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

        [DataMember(Name = "AnimalSolds")]
        public virtual ICollection<AnimalSold> AnimalSolds { get; set; }

        [DataMember(Name = "Messages")]
        public virtual ICollection<Message> Messages { get; set; }

        [DataMember(Name = "Courses")]
        public virtual ICollection<JoinCustomerCourse> Courses { get; set; }
    }
}
