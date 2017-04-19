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
        public static void Library<T>(PetShopDBContext datacontxt, T items)
        {
            if (items is IEnumerable<Animal>)
            {
                List<Animal> casteditems = items as List<Animal>;
                datacontxt.Animals.AddRange(casteditems);
            }
            else if (items is IEnumerable<Customer>)
            {
                List<Customer> casteditems = items as List<Customer>;
                datacontxt.Customers.AddRange(casteditems);
            }
            else
            {
                MessageBox.Show("The to be persisted does not exist in the database");
            }
        }
    }
}
