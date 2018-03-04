using PetsEntityLib.DataBaseContext;
using PetsEntityLib.Entities;
using PetsEntityLib.PetsExceptions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsEntityLib.EntityExtensions
{
    public static class MarkEntityDelete
    {
        public static void TagEntitiesAsDeleted<T>(this PetShopDBContext dbContext, IList<T> collection)
            where T : class
        {
            if (collection == null || collection.Count <= 0)
            {
                var reason = collection == null
                        ? "null" : "equal or less than zero";
                var message = string.Format("Tagging entities as deleted could " +
                        "not be executed because to the internal " +
                        "list being {0}", reason);
                throw new PetsEntityException(message);
            }

            foreach (var item in collection)
            {
                dbContext.Entry<T>(item).State = EntityState.Deleted;
                /* Our design pattern for this application was to
                 * have a sepration were all transactions create 
                 * a temporary db-context to communicate with the 
                 * database.
                 * Because of the sepertaion, we work in a disconneted
                 * way, which means that we have to manually set 
                 * the entity-state of the entity before we save 
                 * the object to the database.
                 * 
                 * If we do not specify an enity-state, then the 
                 * entity framework will throw an error.
                 * */
            }
        }
    }
}
