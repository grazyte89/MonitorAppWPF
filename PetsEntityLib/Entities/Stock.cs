using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Runtime.Serialization;

namespace PetsEntityLib.Entities
{
    [Serializable]
    [DataContract(Name = "Stock")]
    public class Stock : IEntityDaBase
    {
        [DataMember(Name = "ID")]
        public int ID { get; set; }

        [DataMember(Name = "NAME")]
        public string NAME { get; set; }

        [DataMember(Name = "STOCKLEFT")]
        public int STOCKLEFT { get; set; }

        [DataMember(Name = "PRICE")]
        public double PRICE { get; set; }

        [DataMember(Name = "ITEM_PRICE")]
        public double ITEM_PRICE { get; set; }

        [DataMember(Name = "MARKUP")]
        public double MARKUP { get; set; }

        [DataMember(Name = "PRICE_TOMEET_MARK")]
        public double PRICE_TOMEET_MARK { get; set; }

        [DataMember(Name = "DATE")]
        public DateTime? DATE { get; set; }

        [DataMember(Name = "TARGETSALEMK")]
        public double? TARGETSALEMK { get; set; }
    }
}
