using PetsEntityLib.DataBaseValues;
using PetsEntityLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCollectionLib
{
    public static class TestOne
    {
        public static IList<IEntityDaBase> GenerateMultipleEntites
        {
            get
            {
                List<IEntityDaBase> entitiesCollection = new List<IEntityDaBase>();
                for (int index = 0; index < 100; index++)
                {
                    var animal = new Animal
                    {
                        NAME = "Johnatheen " + index,
                        AGE = index,
                        GENDER = DbConstantsEnums.Male,
                        TYPE = "Frog " + index
                    };
                    var customer = new Customer
                    {
                        FIRSTNAME = "FirstName " + index + " first",
                        LASTNAME = "LastName " + index + " last",
                        AGE = index,
                        ADDRESS = index + " Steet road"
                    };
                    var stock = new Stock
                    {
                        NAME = "StockIndex " + index,
                        STOCKLEFT = index,
                        ITEM_PRICE = index,
                        MARKUP = index,
                        PRICE = index,
                        PRICE_TOMEET_MARK = index,
                        DATE = DateTime.Now
                    };
                    entitiesCollection.Add(animal);
                    entitiesCollection.Add(customer);
                    entitiesCollection.Add(stock);
                }
                return entitiesCollection;
            }
        }
    }
}
