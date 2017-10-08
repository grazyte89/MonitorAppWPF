using MonitorAppMVVM.DbControlsVM.VmSharedGeneric;
using PetsEntityLib.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonitorAppMVVM.DbControlsVM.StockVm
{
    public class StockViewModel : GenericBaseViewModel
    {
        //public event PropertyChangedEventHandler PropertyChanged;

        public string ExistingOrNewStock { get; set; }

        private ObservableCollection<Stock> _stockList;
        public ObservableCollection<Stock> StockList
        {
            get
            {
                return _stockList;
            }
            set
            {
                _stockList = value;
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("StockList"));
                InvokePropertyChange(this, "StockList");
            }
        }

        private Stock _selectedStock;
        public Stock SelectedStock
        {
            get
            {
                return _selectedStock;
            }
            set
            {
                _selectedStock = value;
                CurrentStock = _selectedStock;
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedStock"));
                InvokePropertyChange(this, "SelectedStock");
            }
        }

        private Stock _currentStock;
        public Stock CurrentStock
        {
            get
            {
                return _currentStock;
            }
            set
            {
                _currentStock = value;
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentStock"));
                InvokePropertyChange(this, "CurrentStock");
            }
        }

        private bool _stockListAccessEnabled;
        public bool StockListAccessEnabled
        {
            get
            {
                return _stockListAccessEnabled;
            }
            set
            {
                _stockListAccessEnabled = value;
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("StockListAccessEnabled"));
                InvokePropertyChange(this, "StockListAccessEnabled");
            }
        }

        private EditStockCommand _editStockCommand;
        public ICommand EditStockCommand
        {
            get
            {
                return _editStockCommand;
            }
        }

        private NewStockCommand _newStockCommand;
        public ICommand NewStockCommand
        {
            get
            {
                return _newStockCommand;
            }
        }

        private RetrieveStockCommand _retrieveStockCommand;
        public ICommand RetrieveStockCommand
        {
            get
            {
                return _retrieveStockCommand;
            }
        }

        private SaveStockCommand _saveStockCommand;
        public ICommand SaveStockCommand
        {
            get
            {
                return _saveStockCommand;
            }
        }

        public StockViewModel()
        {
            _editStockCommand = new EditStockCommand(this);
            _newStockCommand = new NewStockCommand(this);
            _retrieveStockCommand = new RetrieveStockCommand(this);
            _saveStockCommand = new SaveStockCommand(this);
        }
    }
}
