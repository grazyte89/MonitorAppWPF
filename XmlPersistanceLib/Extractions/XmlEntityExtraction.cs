using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XmlPersistanceLib.Extractions
{
    public class XmlEntityExtraction<T> : IExtracted<T> where T : PetsEntityLib.Entities.IEntityDaBase
    {
        private IList<T> _list;
        public string Location { get; set; }

        public XmlEntityExtraction(string location)
        {
            this.Location = location;
        }

        public IList<T> Data
        {
            get
            {
                return _list;
            }
        }

        public bool ExecuteExtraction()
        {
            try
            {
                if (Location == null)
                    return false;

                using (FileStream reader = new FileStream(Location, FileMode.Open))
                {
                    DataContractSerializer xmlserializer = new DataContractSerializer(typeof(List<T>));
                    _list = (List<T>)xmlserializer.ReadObject(reader);
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Hello " + e.Message);
                return false;
            }
            return true;
        }
    }
}
