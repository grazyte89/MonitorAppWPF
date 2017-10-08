using MonitorAppMVVM.UiConstantsMvvm;
using PetsEntityLib.DataBasePersistances;
using PetsEntityLib.DataBaseUpdates;
using PetsEntityLib.Entities;
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
            if (_stockViewModel.ExistingOrNewStock.Equals(Constants.New)
                    && _stockViewModel.CurrentStock != null)
                this.CreateNewStock(_stockViewModel.CurrentStock);
            else if (_stockViewModel.ExistingOrNewStock.Equals(Constants.Edit)
                    && _stockViewModel.CurrentStock != null)
                this.UpdateStock(_stockViewModel.CurrentStock);
        }

        private void CreateNewStock(Stock stock)
        {
            CreateStocksClass createStock = new CreateStocksClass(null);
            createStock.AddItem(stock);
            createStock.SaveCreatedItems(); 
        }

        private void UpdateStock(Stock stock)
        {
            UpdateStockClass updateStock = new UpdateStockClass(stock);
            updateStock.SaveUpdate();
        }
    }
}
