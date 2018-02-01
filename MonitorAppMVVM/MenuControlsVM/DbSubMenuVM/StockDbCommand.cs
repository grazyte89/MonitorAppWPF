using MonitorAppMVVM.DbControlsVM.StockVm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonitorAppMVVM.MenuControlsVM.DbSubMenuVM
{
    public class StockDbCommand : ICommand
    {
        private DBSubMenuControlViewModel _dbSubMenuControlViewModel;

        public event EventHandler CanExecuteChanged;

        public StockDbCommand(DBSubMenuControlViewModel dbSubMenuControlViewModel)
        {
            _dbSubMenuControlViewModel = dbSubMenuControlViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _dbSubMenuControlViewModel.DbControlViewModel = new StockViewModel();
        }
    }
}
