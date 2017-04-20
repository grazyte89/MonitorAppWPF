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
            if (File.Exists(_location))
            {
                Thread emptyingPreviousSession = new Thread(PersistPreviousSession);
                emptyingPreviousSession.Start();
                emptyingPreviousSession.Join();
            }

            this.SaveDataToCache(list);
            var items = LoadCachedData();
        }

        private void SaveDataToCache<T>(IList<T> list) where T : IEntityDaBase
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
                this.ErrorMessage("Error encountered when trying to save cacheed data."
                     + " Location: SaveCahcedData :: PersistEntityAsyncro");
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

                if (dataLoaded != null)
                    return (dataLoaded as IEnumerable<object>).Cast<IEntityDaBase>().ToList();
            }
            catch (Exception exception)
            {
                this.ErrorMessage("Error encountered when trying to load cacheed data."
                     + " Location: LoadCahcedData :: PersistEntityAsyncro");
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
                this.ErrorMessage("Error encountered when trying to load cacheed data to database."
                     + " Location: SaveToCahcedData :: PersistEntityAsyncro");
            }
        }

        private void PersistPreviousSession()
        {
            IList<IEntityDaBase> previousCachedData = LoadCachedData();
        }

        private void ErrorMessage(string value)
        {
            MessageBox.Show(value);
        }
    }
}

// http://stackoverflow.com/questions/15118015/binary-deserializing-generic-object-in-c-sharp
// http://stackoverflow.com/questions/23197095/save-structure-in-binary-file-and-then-read-from-it
