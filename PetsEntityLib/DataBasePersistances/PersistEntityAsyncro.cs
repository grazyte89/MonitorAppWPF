using PetsEntityLib.DataBaseContext;
using PetsEntityLib.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        private string _location;
        private ReaderWriterLockSlim _fileLock;

        public PersistEntityAsyncro()
        {
            _location = ConfigurationManager.AppSettings["BinaryCachingFolder"] + "DbTestbinary.bin";
            _fileLock = new ReaderWriterLockSlim();
        }

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
            this.SaveToDataBase(items);
        }

        private void SaveDataToCache<T>(IList<T> list) where T : IEntityDaBase
        {
            for (int attemp = 0; attemp < 1000000; attemp++)
            {
                if (TrySavingDataToCache(list))
                    break;
            }
        }

        private bool TrySavingDataToCache<T>(IList<T> list) where T : IEntityDaBase
        {
            try
            {
                using (FileStream write = new FileStream(_location, FileMode.Append, FileAccess.Write, FileShare.None))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(write, list);
                }
                return true;
            }
            catch (Exception e)
            {
                this.ErrorMessage("Error encountered when trying to save cacheed data.",
                    "Location: SaveCahcedData :: PersistEntityAsyncro");
                return false;
            }
        }

        private IList<IEntityDaBase> LoadCachedData()
        {
            object dataLoaded = null;
            for (int attempt = 0; attempt < 1000000; attempt++)
            {
                if (TryLoadingDataFromCache(ref dataLoaded))
                {
                    if (dataLoaded != null)
                        return (dataLoaded as IEnumerable<object>).Cast<IEntityDaBase>().ToList();
                    break;
                }

                if (dataLoaded == null)
                    break;
            }

            return null;
        }

        private bool TryLoadingDataFromCache(ref object loadedData)
        {
            try
            {
                using (FileStream read = new FileStream(_location, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    loadedData = formatter.Deserialize(read);
                    if (loadedData != null)
                        read.SetLength(0);
                }
                return true;
            }
            catch (FileLoadException)
            {
                return false;
            }
            catch (Exception e)
            {
                this.ErrorMessage("Error encountered when trying to load cached data.",
                    "Location: LoadCahcedData :: PersistEntityAsyncro");
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
            catch (Exception e)
            {
                this.ErrorMessage("Error encountered when trying to load cached data to database.",
                    "Location: SaveToCahcedData :: PersistEntityAsyncro");
                this.BackupFailedDatabasePersistence(items);
            }
        }

        private void BackupFailedDatabasePersistence<T>(IList<T> items)
        {
            try
            {
                this.SaveDataToCache<IEntityDaBase>(items as IList<IEntityDaBase>);
            }
            catch (Exception e)
            {
                this.ErrorMessage("Error ecountered trying to generic to IEntityDaBase.",
                    "Location: BackupFailedDatabasePersistence :: PersistEntityAsyncro");
            }
        }

        private void PersistPreviousSession()
        {
            IList<IEntityDaBase> previousCachedData = LoadCachedData();
            if (previousCachedData != null)
                this.SaveToDataBase(previousCachedData);
        }

        private void ErrorMessage(params string[] errorMessages)
        {
            string message = string.Empty;
            foreach (string sentence in errorMessages)
            {
                message += sentence + Environment.NewLine;
            }
            System.Console.WriteLine(message);
        }
    }
}

// http://stackoverflow.com/questions/15118015/binary-deserializing-generic-object-in-c-sharp
// http://stackoverflow.com/questions/23197095/save-structure-in-binary-file-and-then-read-from-it
