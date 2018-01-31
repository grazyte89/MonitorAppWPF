using MonitorAppMVVM.VmSharedGeneric;
using PetsEntityLib.DataBaseExtractions;
using PetsEntityLib.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonitorAppMVVM.DbControlsVM.StockVm
{
    public class RetrieveStockCommand : GenericBaseCommand
    {
        private StockViewModel _stockViewModel;

        public RetrieveStockCommand(StockViewModel stockViewModel)
        {
            _stockViewModel = stockViewModel;
        }

        public override void InvokeActione(object parameter)
        {
            _stockViewModel.StockList = 
                new ObservableCollection<Stock>(RetrieveStocks.GetAllStocks()); 
            _stockViewModel.StockListAccessEnabled = true;
        }
    }
}
