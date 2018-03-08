using PetsEntityLib.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace PetsEntityLib.EntityExtensions
{
    public static class EntityDeepClone
    {
        public static T DeepClone<T>(this IEntityDaBase entity)
            where T : IEntityDaBase
        {
            try
            {
                if (entity is T castedObject)
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        formatter.Serialize(memoryStream, castedObject);
                        memoryStream.Position = 0;
                        return (T)formatter.Deserialize(memoryStream);
                    }
                }
                return default(T);
            }
            catch
            {
                return default(T);
            }
        }
    }
}