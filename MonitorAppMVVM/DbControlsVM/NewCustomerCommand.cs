using MonitorAppMVVM.UiConstantsMvvm;
using PetsEntityLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonitorAppMVVM.DbControlsVM
{
    public class NewCustomerCommand : ICommand
    {
        private CustomerViewModel _customerViewModel;

        public event EventHandler CanExecuteChanged;

        public NewCustomerCommand(CustomerViewModel customerViewModel)
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
            _customerViewModel.ExistingOrNewCustomer = Constants.New;
            _customerViewModel.CurrentCustomer = new Customer();
        }
    }
}
