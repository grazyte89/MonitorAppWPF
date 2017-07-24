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

        [DataMember(Name = "SENDER")]
        public string SENDER { get; set; }

        [DataMember(Name = "RECEIVER")]
        public string RECEIVER { get; set; }

        [DataMember(Name = "MULTIPLE_RECEIVER")]
        public string MULTIPLE_RECEIVER { get; set; }

        [DataMember(Name = "TEXT")]
        public string TEXT { get; set; }

        [DataMember(Name = "MESSAGE_HEAD")]
        public string MESSAGE_HEAD { get; set; }

        [DataMember(Name = "CREATE_DATE")]
        public DateTime CREATE_DATE { get; set; }

        [DataMember(Name = "SEND_BY_DATE")]
        public DateTime SEND_BY_DATE { get; set; }

        [DataMember(Name = "CUSTOMER_ID")]
        public int CUSTOMER_ID { get; set; }

        [ForeignKey("CUSTOMER_ID")] // the string in foreign key is pointing to the customer_id property in this class
        [DataMember(Name = "Customer")]
        public virtual Customer Customer { get; set; }
    }
}
