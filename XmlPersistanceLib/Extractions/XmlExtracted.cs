using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XmlPersistanceLib.Extractions
{
    public class XmlExtracted<T> : IExtracted<T> where T : PetsEntityLib.Entities.IEntityDaBase
    {
        private IList<T> _list;
        public string Location { get; set; }

        public XmlExtracted(string location)
        {

        }

        public IList<T> Data
        {
            get
            {
                if (_list != null)
                    return _list;
                return null;
            }
        }

        public void ExecuteExtraction()
        {
            try
            {
                using (StreamReader reader = new StreamReader(Location))
                {
                    XmlSerializer xmlserializer = new XmlSerializer(typeof(List<T>));
                    _list = (List<T>)xmlserializer.Deserialize(reader);
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Hello " + e.Message);
            }
        }
    }
}
