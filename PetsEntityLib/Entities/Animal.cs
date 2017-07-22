using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Runtime.Serialization;

namespace PetsEntityLib.Entities
{
    [Serializable]
    [DataContract(Name = "Animal")]
    public class Animal : IEntityDaBase
    {
        
        public Animal()
        {
            AnimalSolds = new HashSet<AnimalSold>();
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
        public DateTime? VACINATION { get; set; }

        [DataMember(Name = "CHECKUP")]
        public DateTime? CHECKUP { get; set; }

        [DataMember(Name = "STATUS")]
        public string STATUS { get; set; }

        [DataMember(Name = "AnimalSolds")]
        public virtual ICollection<AnimalSold> AnimalSolds { get; set; }
    }
}
