using PetsEntityLib.DataBaseExtractions;
using PetsEntityLib.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonitorAppMVVM.DbControlsVM
{
    public class CustomerViewModel : INotifyPropertyChanged
    {
        private IList<Customer> _customerList;
        private RetrieveCustomerButton _btnRetrieveCustomer;
        private EditCustomerButton _btnEditCustomers;

        public event PropertyChangedEventHandler PropertyChanged;

        public Customer CurrentCustomer { get; set; }
        public bool CustomerListAccessEnabled { get; set; }
        public string NewEditMode { get; set; }

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
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedCustomer"));
            }
        }

        public IList<Customer> CustomersList
        {
            get { return _customerList; }
            set { _customerList = value; }
        }

        public ICommand BtnRetrieveCustomers
        {
            get
            {
                return _btnRetrieveCustomer;
            }
        }

        public ICommand BtnEditCustomers
        {
            get
            {
                return _btnEditCustomers;
            }
        }

        public CustomerViewModel()
        {
            _btnRetrieveCustomer = new RetrieveCustomerButton(this);
            _btnEditCustomers = new EditCustomerButton(this);
            _customerList = RetrieveCustomers.GetAllCustomers();

            CustomerListAccessEnabled = true;
        }
    }
}
