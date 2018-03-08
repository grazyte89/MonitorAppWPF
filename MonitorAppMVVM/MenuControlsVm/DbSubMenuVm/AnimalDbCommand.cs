using MonitorAppMVVM.DbControlsVM.AnimalVm;
using MonitorAppMVVM.VmSharedGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonitorAppMVVM.MenuControlsVM.DbSubMenuVM
{
    public class AnimalDbCommand : ICommand
    {
        private DBSubMenuControlViewModel _dbSubMenuViewModel;

        public event EventHandler CanExecuteChanged;

        public AnimalDbCommand(DBSubMenuControlViewModel dbSubMenuViewModel)
        {
            _dbSubMenuViewModel = dbSubMenuViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _dbSubMenuViewModel.DbControlViewModel = new AnimalViewModel();
        }
    }
}
