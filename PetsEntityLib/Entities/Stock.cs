using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PetsEntityLib.Entities
{
    [DataContract(Name = "Stock")]
    public partial class Stock : IEntityDaBase
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
        public Nullable<System.DateTime> DATE { get; set; }
        [DataMember(Name = "TARGETSALEMK")]
        public Nullable<double> TARGETSALEMK { get; set; }
    }
}
