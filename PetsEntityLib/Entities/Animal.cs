using System;
using System.Collections.Generic;

namespace PetsEntityLib.Entities
{
    public partial class Animal : IEntityBase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Animal()
        {
            this.AnimalSolds = new HashSet<AnimalSold>();
        }
    
        public int ID { get; set; }
        public string NAME { get; set; }
        public int AGE { get; set; }
        public string GENDER { get; set; }
        public string TYPE { get; set; }
        public Nullable<System.DateTime> VACINATION { get; set; }
        public Nullable<System.DateTime> CHECKUP { get; set; }
        public string STATUS { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AnimalSold> AnimalSolds { get; set; }
    }
}
