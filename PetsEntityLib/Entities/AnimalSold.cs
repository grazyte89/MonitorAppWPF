using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PetsEntityLib.Entities
{
    [Serializable]
    [DataContract(Name = "AnimalSold")]
    public partial class AnimalSold : IEntityDaBase
    {
        [DataMember(Name = "ID")]
        public int ID { get; set; }
        [DataMember(Name = "ANIMAL_ID")]
        public int ANIMAL_ID { get; set; }
        [DataMember(Name = "OWNER_ID")]
        public int OWNER_ID { get; set; }

        [DataMember(Name = "Animal")]
        public virtual Animal Animal { get; set; }
        [DataMember(Name = "Customer")]
        public virtual Customer Customer { get; set; }
    }
}
