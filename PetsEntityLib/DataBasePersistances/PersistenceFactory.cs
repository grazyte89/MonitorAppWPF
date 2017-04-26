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
        private static void Library<T>(PetShopDBContext datacontxt, T item)
        {
            if (item is Animal)
            {
                Animal casteditems = item as Animal;
                datacontxt.Animals.Add(casteditems);
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

        public static void AssociateWithEntities<T>(PetShopDBContext datacontxt, T items)
        {
            if (items is IEnumerable<IEntityDaBase>)
            {
                List<IEntityDaBase> castedItems = items as List<IEntityDaBase>;
                foreach (IEntityDaBase item in castedItems)
                {
                    Library(datacontxt, item);
                }
            }
        }
    }
}
