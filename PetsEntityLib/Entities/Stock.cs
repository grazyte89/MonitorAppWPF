using System;
using System.Collections.Generic;

namespace PetsEntityLib.Entities
{
    public partial class Stock : IEntityBase
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public int STOCKLEFT { get; set; }
        public double PRICE { get; set; }
        public double ITEM_PRICE { get; set; }
        public double MARKUP { get; set; }
        public double PRICE_TOMEET_MARK { get; set; }
        public Nullable<System.DateTime> DATE { get; set; }
        public Nullable<double> TARGETSALEMK { get; set; }
    }
}
