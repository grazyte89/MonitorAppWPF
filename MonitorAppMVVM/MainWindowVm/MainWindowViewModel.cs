using MonitorAppMVVM.ContainerVM;
using MonitorAppMVVM.VmSharedGeneric;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace MonitorAppMVVM.MainWindowVM
{
    public class MainWindowViewModel : INotifyPropertyChanged //IPrincipleViewModel,
    {
        public string CurrentViewModelName { get { return "MainWindowViewModel"; } }
        public event PropertyChangedEventHandler PropertyChanged;

        private IGenericBaseViewModel _dbSubMenuControl;
        public IGenericBaseViewModel DbSubMenuViewModel
        {
            get
            {
                return _dbSubMenuControl;
            }
            set
            {
                _dbSubMenuControl = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DbSubMenuViewModel"));
            }
        }

        private DbSubMenuCommand _dbSubMenuCommand;
        public ICommand DbSubMenuCommand
        {
            get
            {
                return _dbSubMenuCommand;
            }
        }

        public MainWindowViewModel()
        {
            _dbSubMenuCommand = new DbSubMenuCommand(this);
        }
    }
}
// https://stackoverflow.com/questions/42709379/how-to-display-user-control-within-the-main-window-in-wpf-using-mvvm
