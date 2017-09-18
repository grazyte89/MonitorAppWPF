using PetsEntityLib.DataBaseExtractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonitorAppMVVM.DbControlsVM
{
    public class RetrieveCustomerButton : ICommand
    {
        private CustomerViewModel _customerViewModel;

        public event EventHandler CanExecuteChanged;

        public RetrieveCustomerButton(CustomerViewModel customerViewModel)
        {
            _customerViewModel = customerViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true; ;
        }

        public void Execute(object parameter)
        {
            _customerViewModel.CustomersList = RetrieveCustomers.GetAllCustomers();
        }
    }
}
