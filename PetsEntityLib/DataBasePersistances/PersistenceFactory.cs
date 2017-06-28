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
        private static void Library(PetShopDBContext datacontxt, IEntityDaBase item)
        {
            if (item is Animal)
            {
                Animal casteditems = item as Animal;
                //datacontxt.Animals.Add(casteditems);
                datacontxt.Set(item.GetType()).Add(item);
            }
            else if (item is Customer)
            {
                Customer casteditem = item as Customer;
                datacontxt.Customers.Add(casteditem);
            }
            else
            {
                MessageBox.Show("The to be persisted does not exist in the database");
            }
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
                Library(dataContext, item);
        }
    }
}
