using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Runtime.Serialization;

namespace PetsEntityLib.Entities
{
    [Serializable]
    [DataContract(Name = "AnimalSold")]
    public class AnimalSold : IEntityDaBase
    {
        [DataMember(Name = "ID")]
        public int ID { get; set; }

        [DataMember(Name = "ANIMAL_ID")]
        public int ANIMAL_ID { get; set; }

        [DataMember(Name = "OWNER_ID")]
        public int OWNER_ID { get; set; }

        [ForeignKey("ANIMAL_ID")]
        [DataMember(Name = "Animal")]
        public virtual Animal Animal { get; set; }

        [ForeignKey("OWNER_ID")]
        [DataMember(Name = "Customer")]
        public virtual Customer Customer { get; set; }
    }
}
