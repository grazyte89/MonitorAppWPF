using MonitorAppMVVM.VmSharedGeneric;
using PetsEntityLib.DataBaseExtractions;
using PetsEntityLib.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonitorAppMVVM.DbControlsVM.CustomerVm
{
    public class CustomerViewModel : IGenericBaseViewModel, INotifyPropertyChanged
    {
        private IList<Customer> _customerList;

        public event PropertyChangedEventHandler PropertyChanged;
        public string ExistingOrNewCustomer { get; set; }

        public string CurrentViewModelName
        {
            get
            {
                return "CustomerViewModel";
            }
        }

        private bool _customerListAccessEnabled;
        public bool CustomerListAccessEnabled
        {
            get
            {
                return _customerListAccessEnabled;
            }
            set
            {
                _customerListAccessEnabled = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CustomerListAccessEnabled"));
            }
        }

        private Customer _currentCustomer;
        public Customer CurrentCustomer
        {
            get
            {
                return _currentCustomer;
            }
            set
            {
                _currentCustomer = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentCustomer"));
            }
        }

        private Customer _selectedCustomer;
        public Customer SelectedCustomer
        {
            get
            {
                return _selectedCustomer;
            }
            set
            {
                _selectedCustomer = value;
                this.CurrentCustomer = _selectedCustomer;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedCustomer"));
            }
        }

        public IList<Customer> CustomersList
        {
            get
            {
                return _customerList;
            }
            set
            {
                _customerList = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CustomersList"));
            }
        }

        private RetrieveCustomerCommand _retrieveCustomersCommand;
        public ICommand RetrieveCustomersCommand
        {
            get
            {
                return _retrieveCustomersCommand;
            }
        }

        private EditCustomerCommad _editCustomerCommand;
        public ICommand EditCustomerCommand
        {
            get
            {
                return _editCustomerCommand;
            }
        }

        private NewCustomerCommand _newCustomerCommand;
        public ICommand NewCustomerCommand
        {
            get
            {
                return _newCustomerCommand;
            }
        }

        private SaveCustomerCommand _saveCustomerCommand;
        public ICommand SaveCustomerCommand
        {
            get
            {
                return _saveCustomerCommand;
            }
        }

        public CustomerViewModel()
        {
            _retrieveCustomersCommand = new RetrieveCustomerCommand(this);
            _editCustomerCommand = new EditCustomerCommad(this);
            _newCustomerCommand = new NewCustomerCommand(this);
            _saveCustomerCommand = new SaveCustomerCommand(this);
            //_customerList = RetrieveCustomers.GetAllCustomers();

            CustomerListAccessEnabled = true;
        }
    }
}
