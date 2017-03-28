using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlPersistanceLib.Extractions
{
    public class XmlExtracted<T> : IExtracted<T>
    {
        private IList<T> _list;

        public IList<T> ExtractedData
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
