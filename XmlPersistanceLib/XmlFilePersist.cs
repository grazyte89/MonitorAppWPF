using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using XmlPersistanceLib.Persistances;

namespace XmlPersistanceLib
{
    public class XmlFilePersist<T> : IPersistance
    {
        public T Message { get; set; }
        private string _location;

        public XmlFilePersist(T message)
        {
            this.Message = message;
            _location = "";
        }

        public void Persist()
        {
            try
            {
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(ConfigurationManager.AppSettings["XmlTestPersist"], true))
                {
                    XmlSerializer xmlfile = new XmlSerializer(typeof(T));
                    xmlfile.Serialize(writer, Message);
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}
