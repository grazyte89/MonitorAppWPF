using PetsEntityLib.DataBaseContext;
using PetsEntityLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetsEntityLib.DataBasePersistances
{
    public static class PersistenceFactory
    {
        private static void AddToDbContextSet(PetShopDBContext datacontxt, IEntityDaBase item)
        {
            //Type type = item.GetType();
            datacontxt.Set(item.GetType()).Add(item);
        }

        public static void AssociateWithEntities<T>(PetShopDBContext dataContext, T items)
        {
            if (items is IEnumerable<IEntityDaBase>)
            {
                List<IEntityDaBase> castedItems = items as List<IEntityDaBase>;
                ScheduleAssociateWithEntites(dataContext, castedItems);
            }
        }

        private static void ScheduleAssociateWithEntites(PetShopDBContext dataContext, IList<IEntityDaBase> list)
        {
            foreach (IEntityDaBase item in list)
                AddToDbContextSet(dataContext, item);
        }
    }
}
