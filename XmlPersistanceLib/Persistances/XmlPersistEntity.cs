using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace XmlPersistanceLib.Persistances
{
    public class XmlPersistEntity<T> : IPersistance
    {
        public T Value { get; set; }
        public string Location { get; set; }

        public XmlPersistEntity(T message)
        {
            this.Value = message;
        }

        public bool Persist()
        {
            try
            {
                if (Location == null)
                    return false;

                using (FileStream writer = new FileStream(Location, FileMode.Create))
                {
                    DataContractSerializer xmlfile = new DataContractSerializer(typeof(T));
                    xmlfile.WriteObject(writer, Value);
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
