using PetsEntityLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsEntityLib.DataBaseDeletions
{
    public interface IDBDeletion<T> where T : IEntityDaBase
    {
        void AddItemForDeletion(T value);
        void DeleteItems();
    }
}
