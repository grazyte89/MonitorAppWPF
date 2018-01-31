using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorAppMVVM.VmSharedGeneric
{
    public interface IContainerViewModel : IGenericBaseViewModel
    {
        IGenericBaseViewModel ViewModelContent { get; set; }
    }
}
