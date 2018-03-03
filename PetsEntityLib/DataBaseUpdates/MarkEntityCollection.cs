using PetsEntityLib.DataBaseContext;
using PetsEntityLib.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PetsEntityLib.DataBaseUpdates
{
    public static class MarkEntityCollection
    {
        /*public static void LoadAndMarkEnityCollection<S, T>(this IEntityDaBase entityObject, PetShopDBContext dbcontext, 
            Func<S, ICollection<T>> loadFunction) where S: class where T : class
        {
           dbcontext.Entry(entityObject).Collection(loadFunction.ToString()).Load();
        }*/

        public static void AddNewItems<TEntity>(this PetShopDBContext dbContext, ICollection<TEntity> collection,
            Expression<Func<TEntity, bool>> lamdaQuery) where TEntity : class
        {
            var newItems = collection.AsQueryable().Where(lamdaQuery)
                    .ToList();

            if (newItems != null)
            {
                foreach (var item in newItems)
                {
                    var castedItem = item as IEntityDaBase;
                    if (castedItem != null)
                    {
                        dbContext.Entry(castedItem).State = EntityState.Added;
                    }
                }
            }
        }
    }
}
