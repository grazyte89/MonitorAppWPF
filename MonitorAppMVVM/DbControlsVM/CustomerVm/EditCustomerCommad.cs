using MonitorAppMVVM.UiConstantsMvvm;
using PetsEntityLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonitorAppMVVM.DbControlsVM.CustomerVm
{
    public class EditCustomerCommad : ICommand
    {
        private CustomerViewModel _customerViewModel;

        public event EventHandler CanExecuteChanged;

        public EditCustomerCommad(CustomerViewModel customerViewModel)
        {
            _customerViewModel = customerViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _customerViewModel.CustomerListAccessEnabled = false;
            _customerViewModel.ExistingOrNewCustomer = Constants.Edit;
            //_customerViewModel.SelectedCustomer = new Customer();
        }
    }
}
