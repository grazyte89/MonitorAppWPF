using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonitorAppMVVM.DbControlsVM
{
    public class EditCustomerButton : ICommand
    {
        private CustomerViewModel _customerViewModel;

        public event EventHandler CanExecuteChanged;

        public EditCustomerButton(CustomerViewModel customerViewModel)
        {
            _customerViewModel = customerViewModel;
        }

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            _customerViewModel.CustomerListAccessEnabled = false;
        }
    }
}
