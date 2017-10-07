using MonitorAppMVVM.UiConstantsMvvm;
using PetsEntityLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonitorAppMVVM.DbControlsVM.StockVm
{
    public class NewStockCommand : ICommand
    {
        private StockViewModel _stockViewModel;

        public event EventHandler CanExecuteChanged;

        public NewStockCommand(StockViewModel stockViewModel)
        {
            _stockViewModel = stockViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _stockViewModel.StockListAccessEnabled = false;
            _stockViewModel.ExistingOrNewStock = Constants.New;
            _stockViewModel.CurrentStock = new Stock();
        }
    }
}