using PetsEntityLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsEntityLib.DataBasePersistances
{
    public interface IDBPersistance<T> where T : IEntityDaBase
    {
        void AddChanges(T value);
        void SaveChanges();
    }
}
