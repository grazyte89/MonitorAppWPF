using MonitorAppMVVM.VmSharedGeneric;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorAppMVVM.ContainerVM
{
    public class DbContainerViewModel : IContainerViewModel, INotifyPropertyChanged
    {
        public string CurrentViewModelName { get { return "DbContainerViewModel"; } }
        public event PropertyChangedEventHandler PropertyChanged;

        private IGenericBaseViewModel _viewModelContent;
        public IGenericBaseViewModel ViewModelContent
        {
            get
            {
                return _viewModelContent;
            }
            set
            {
                _viewModelContent = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ViewModelContent"));
            }
        }

        public DbContainerViewModel()
        {
            //
        }
    }
}
