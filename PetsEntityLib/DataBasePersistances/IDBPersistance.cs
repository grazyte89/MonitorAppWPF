using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsEntityLib.DataBasePersistances
{
    public interface IDBPersistance<T>
    {
        void AddChanges(T value);
        void SaveChanges();
    }
}
