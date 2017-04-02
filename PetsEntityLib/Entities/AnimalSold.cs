using System;
using System.Collections.Generic;

namespace PetsEntityLib.Entities
{
    public partial class AnimalSold : IEntityBase
    {
        public int ID { get; set; }
        public int ANIMAL_ID { get; set; }
        public int OWNER_ID { get; set; }
    
        public virtual Animal Animal { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
