using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorAppMVVM.VmSharedGeneric
{
    public interface IPrincipleViewModel : IGenericBaseViewModel
    {
        IGenericBaseViewModel DbSubMenuViewModel { get; set; }
        IGenericBaseViewModel ViewModelContainer { get; set; }
    }
}
