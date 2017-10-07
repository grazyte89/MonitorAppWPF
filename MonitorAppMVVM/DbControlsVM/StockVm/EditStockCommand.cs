using MonitorAppMVVM.UiConstantsMvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonitorAppMVVM.DbControlsVM.StockVm
{
    public class EditStockCommand : ICommand
    {
        private StockViewModel _stockViewModel;

        public event EventHandler CanExecuteChanged;

        public EditStockCommand(StockViewModel stockViewModel)
        {
            _stockViewModel = stockViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _stockViewModel.ExistingOrNewStock = Constants.Edit;
            _stockViewModel.StockListAccessEnabled = false;
        }
    }
}