using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Runtime.Serialization;

namespace PetsEntityLib.Entities
{
    [Serializable]
    [DataContract(Name = "Message")]
    public class Message : IEntityDaBase
    {
        [DataMember(Name = "ID")]
        public int ID { get; set; }

        [DataMember(Name = "TEXT")]
        public string TEXT { get; set; }

        public string MESSAGE_HEAD { get; set; }

        [DataMember(Name = "CUSTOMER_ID")]
        public int CUSTOMER_ID { get; set; }

        [ForeignKey("CUSTOMER_ID")]
        [DataMember(Name = "Customer")]
        public virtual Customer Customer { get; set; }
    }
}
