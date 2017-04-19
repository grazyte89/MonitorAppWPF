using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlPersistanceLib.Persistances
{
    public interface IPersistance
    {
        string Location { get; set; }
        bool Persist();
    }
}
