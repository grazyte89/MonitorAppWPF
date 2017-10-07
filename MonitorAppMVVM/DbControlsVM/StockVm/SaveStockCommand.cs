using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonitorAppMVVM.DbControlsVM.StockVm
{
    public class SaveStockCommand : ICommand
    {
        private StockViewModel _stockViewModel;

        public event EventHandler CanExecuteChanged;

        public SaveStockCommand(StockViewModel stockViewModel)
        {
            _stockViewModel = stockViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
