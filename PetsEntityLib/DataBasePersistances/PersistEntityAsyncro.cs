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
using System.Windows.Forms;

namespace PetsEntityLib.DataBasePersistances
{
    public class PersistEntityAsyncro
    {
        private const string _location = @"C:\Users\Abu\Documents\Programming\C#\MonitorAppWPF\DbTestbinary.bin";

        public void Save<T>(IList<T> list) where T : IEntityDaBase
        {
            Thread persitingAsyncroThread = new Thread(() => SavingData<T>(list));
            persitingAsyncroThread.Start();
        }

        private void SavingData<T>(IList<T> list) where T : IEntityDaBase
        {
            /*if (File.Exists(_location))
            {
                Thread emptyingPreviousSession = new Thread(PersistPreviousSession);
                emptyingPreviousSession.Start();
                emptyingPreviousSession.Join();
            }*/

            this.SaveDataToCache(list);
            var items = LoadCachedData();
            this.SaveToDataBase(items);
        }

        private void SaveDataToCache<T>(IList<T> list) where T : IEntityDaBase
        {
            for (int attemp = 0; attemp < 1000; attemp++)
            {
                if (TrySavingDataToCache(list))
                    break;
            }
        }

        private bool TrySavingDataToCache<T>(IList<T> list) where T : IEntityDaBase
        {
            try
            {
                using (FileStream write = new FileStream(_location, FileMode.Append))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(write, list);
                }
                return true;
            }
            catch (Exception exception)
            {
                this.ErrorMessage("Error encountered when trying to save cacheed data."
                     + " Location: SaveCahcedData :: PersistEntityAsyncro");
                return false;
            }
        }

        private IList<IEntityDaBase> LoadCachedData()
        {
            object dataLoaded = null;
            for (int attempt = 0; attempt < 1000; attempt++)
            {
                if (TryLoadingDataFromCache(ref dataLoaded))
                {
                    if (dataLoaded != null)
                        return (dataLoaded as IEnumerable<object>).Cast<IEntityDaBase>().ToList();
                    break;
                }
            }

            return null;
        }

        private bool TryLoadingDataFromCache(ref object loadedData)
        {
            try
            {
                using (FileStream read = new FileStream(_location, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    loadedData = formatter.Deserialize(read);
                }
                return true;
            }
            catch (FileLoadException)
            {
                return false;
            }
            catch (Exception exception)
            {
                this.ErrorMessage("Error encountered when trying to load cacheed data."
                     + " Location: LoadCahcedData :: PersistEntityAsyncro");
                return false;
            }
        }

        private void SaveToDataBase<T>(IList<T> items)
        {
            try
            {
                using (PetShopDBContext _datacontxt = new PetShopDBContext())
                {
                    PersistenceFactory.AssociateWithEntities(_datacontxt, items);
                    _datacontxt.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                this.ErrorMessage("Error encountered when trying to load cached data to database."
                     + " Location: SaveToCahcedData :: PersistEntityAsyncro");
            }
        }

        private void PersistPreviousSession()
        {
            IList<IEntityDaBase> previousCachedData = LoadCachedData();
            this.SaveToDataBase(previousCachedData);
        }

        private void ErrorMessage(string value)
        {
            MessageBox.Show(value);
        }
    }
}

// http://stackoverflow.com/questions/15118015/binary-deserializing-generic-object-in-c-sharp
// http://stackoverflow.com/questions/23197095/save-structure-in-binary-file-and-then-read-from-it
