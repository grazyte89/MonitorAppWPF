using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlPersistanceLib.Extractions
{
    public interface IExtracted<T>
    {
        IList<T> ExtractedData { get; set; }
    }
}
