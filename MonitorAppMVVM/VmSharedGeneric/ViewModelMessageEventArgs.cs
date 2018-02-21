using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorAppMVVM.VmSharedGeneric
{
    public delegate void ViewModelMessageEventHandler(object sender, ViewModelMessageEventArgs args);

    public class ViewModelMessageEventArgs : EventArgs
    {
        public string ErrorMessage { get; set; }

        public ViewModelMessageEventArgs(string errorMessage) : base()
        {
            ErrorMessage = errorMessage;
        }
    }
}
