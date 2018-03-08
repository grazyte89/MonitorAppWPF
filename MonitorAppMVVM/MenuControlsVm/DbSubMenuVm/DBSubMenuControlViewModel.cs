using MonitorAppMVVM.VmSharedGeneric;
using MonitorAppMVVM.MainWindowVM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MonitorAppMVVM.DbControlsVM.AnimalVm;
using MonitorAppMVVM.ContainerVM;

namespace MonitorAppMVVM.MenuControlsVM.DbSubMenuVM
{
    public class DBSubMenuControlViewModel : IGenericBaseViewModel, INotifyPropertyChanged
    {
        public string CurrentViewModelName { get { return "DBSubMenuControlViewModel"; } }
        public event PropertyChangedEventHandler PropertyChanged;

        private IGenericBaseViewModel _dbControlViewModel;
        public IGenericBaseViewModel DbControlViewModel
        {
            get
            {
                return _dbControlViewModel;
            }
            set
            {
                _dbControlViewModel = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DbControlViewModel"));
            }
        }

        private AnimalDbCommand _animalDbCommand;
        public ICommand AnimalDbCommand
        {
            get
            {
                return _animalDbCommand;
            }
        }

        private AnimalSoldDbCommand _animalSoldDbCommand;
        public ICommand AnimalSoldDbCommand
        {
            get
            {
                return _animalSoldDbCommand;
            }
        }

        private CustomerDbCommand _customerDbCommand;
        public ICommand CustomerDbCommand
        {
            get
            {
                return _customerDbCommand;
            }
        }

        private StockDbCommand _stockDbCommand;
        public ICommand StockDbCommand
        {
            get
            {
                return _stockDbCommand;
            }
        }

        public DBSubMenuControlViewModel()
        {
            _animalDbCommand = new AnimalDbCommand(this);
            _animalSoldDbCommand = new AnimalSoldDbCommand(this);
            _customerDbCommand = new CustomerDbCommand(this);
            _stockDbCommand = new StockDbCommand(this);
        }
    }
}
