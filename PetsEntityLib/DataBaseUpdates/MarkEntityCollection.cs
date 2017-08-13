using PetsEntityLib.DataBaseContext;
using PetsEntityLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PetsEntityLib.DataBaseUpdates
{
    public static class MarkEntityCollection
    {
        public static void LoadAndMarkEnityCollection<S, T>(this IEntityDaBase entityObject, PetShopDBContext dbcontext, 
            Func<S, ICollection<T>> loadFunction) where S: class where T : class
        {
           dbcontext.Entry(entityObject).Collection(loadFunction.ToString()).Load();
        }
    }
}
