using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using XmlPersistanceLib.Persistances;

namespace XmlPersistanceLib
{
    public class XmlFilePersistTesti<T> : IPersistance
    {
        public T Value { get; set; }
        public string Location { get; set; }

        public XmlFilePersistTesti(T message)
        {
            this.Value = message;
        }

        public bool Persist()
        {
            try
            {
                if (Location == null)
                    return false;

                using (StreamWriter writer = new StreamWriter(Location, true))
                {
                    XmlSerializer xmlfile = new XmlSerializer(typeof(T));
                    xmlfile.Serialize(writer, Value);
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return false;
            }

            return true;
        }
    }
}
