using MonitorAppMVVM.MenuControlsVm.DbSubMenuVm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonitorAppMVVM.MainWindowVm
{
    public class DbSubMenuCommand : ICommand
    {
        private MainWindowViewModel _mainViewModel;

        public event EventHandler CanExecuteChanged;

        public DbSubMenuCommand(MainWindowViewModel mainViewModel)
        {
            this._mainViewModel = mainViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _mainViewModel.DbSubMenuViewModel = new DBSubMenuControlViewModel(); 
        }
    }
}
