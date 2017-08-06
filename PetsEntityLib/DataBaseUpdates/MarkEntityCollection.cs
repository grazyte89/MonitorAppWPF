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
        public static void LoadAndMarkEnityCollection(this IEntityDaBase entityObject, PetShopDBContext dbcontext, 
            Func<IEntityDaBase, ICollection<IEntityDaBase>> loadFunction)
        {
            dbcontext.Entry(entityObject).Collection(loadFunction.ToString()).Load();
        }
    }
}
