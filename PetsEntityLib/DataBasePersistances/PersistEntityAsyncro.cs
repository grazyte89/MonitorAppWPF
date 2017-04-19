using PetsEntityLib.DataBaseContext;
using PetsEntityLib.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PetsEntityLib.DataBasePersistances
{
    public class PersistEntityAsyncro
    {
        private const string _location = @"C:\Users\Abu\Documents\Programming\C#\MonitorAppWPF\DbTestbinary.bin";

        public void Save<T>(IList<T> list)
        {
            this.SavingData<T>(list);
        }

        private void SavingData<T>(IList<T> list)
        {
            if (File.Exists(_location))
            {
                Thread emptyingPreviousSession = new Thread(PersistPreviousSession);
                emptyingPreviousSession.Start();
                emptyingPreviousSession.Join();
            }

            this.SaveDataToCache(list);
            var items = LoadCachedData();
        }

        private void SaveDataToCache<T>(IList<T> list)
        {
            try
            {
                using (FileStream write = new FileStream(_location, FileMode.Append))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(write, list);
                }
            }
            catch (Exception exception)
            {

            }
        }

        private IList<IEntityDaBase> LoadCachedData()
        {
            object dataLoaded = null;
            try
            {
                using (FileStream read = new FileStream(_location, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    dataLoaded = formatter.Deserialize(read);
                }

                if (dataLoaded is IList<IEntityDaBase>)
                {
                    IList<IEntityDaBase> entities = dataLoaded as IList<IEntityDaBase>;
                    return entities;
                }
            }
            catch (Exception exception)
            {

            }

            return null;
        }

        private void SaveToDataBase<T>(IList<T> items)
        {
            try
            {
                using (PetShopDBContext _datacontxt = new PetShopDBContext())
                {
                    PersistenceFactory.Library(_datacontxt, items);
                    _datacontxt.SaveChanges();
                }
            }
            catch (Exception exception)
            {

            }
        }

        private void PersistPreviousSession()
        {
            IList<IEntityDaBase> previousCachedData = LoadCachedData();
        }
    }
}

// http://stackoverflow.com/questions/15118015/binary-deserializing-generic-object-in-c-sharp
// http://stackoverflow.com/questions/23197095/save-structure-in-binary-file-and-then-read-from-it
