using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PetsEntityLib.Entities
{
    [DataContract(Name = "Animal")]
    public partial class Animal : IEntityDaBase
    {
        public Animal()
        {
            this.AnimalSolds = new HashSet<AnimalSold>();
        }

        [DataMember(Name = "ID")]
        public int ID { get; set; }
        [DataMember(Name = "NAME")]
        public string NAME { get; set; }
        [DataMember(Name = "AGE")]
        public int AGE { get; set; }
        [DataMember(Name = "GENDER")]
        public string GENDER { get; set; }
        [DataMember(Name = "TYPE")]
        public string TYPE { get; set; }
        [DataMember(Name = "VACINATION")]
        public Nullable<System.DateTime> VACINATION { get; set; }
        [DataMember(Name = "CHECKUP")]
        public Nullable<System.DateTime> CHECKUP { get; set; }
        [DataMember(Name = "STATUS")]
        public string STATUS { get; set; }

        [DataMember(Name = "AnimalSold")]
        public virtual ICollection<AnimalSold> AnimalSolds { get; set; }
    }
}
