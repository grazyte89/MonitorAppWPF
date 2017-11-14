using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorAppMVVM.MonitorVM
{
    [Obsolete("Need to figure out out I'm going to connect a section to main")]
    public class MonitorViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _cpuUsage;
        public string CpuUsage
        {
            get
            {
                return _cpuUsage;
            }
            set
            {
                _cpuUsage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CpuUsage"));
            }
        }
    }
}
