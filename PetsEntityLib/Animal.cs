//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PetsEntityLib
{
    using System;
    using System.Collections.Generic;
    
    public partial class Animal
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
