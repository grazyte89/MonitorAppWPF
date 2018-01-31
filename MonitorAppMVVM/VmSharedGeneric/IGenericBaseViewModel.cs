using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorAppMVVM.VmSharedGeneric
{
    public interface IGenericBaseViewModel
    {
        string CurrentViewModelName { get; }
    }
}
