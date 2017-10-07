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

namespace MonitorAppMVVM.DbControlsVM.CustomerVm
{
    public class SaveCustomerCommand : ICommand
    {
        private CustomerViewModel _customerViewModel;

        public event EventHandler CanExecuteChanged;

        public SaveCustomerCommand(CustomerViewModel customerViewModel)
        {
            _customerViewModel = customerViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_customerViewModel.ExistingOrNewCustomer.Equals(Constants.New))
                this.CreateNewCustomer(_customerViewModel.CurrentCustomer);
            else if (_customerViewModel.ExistingOrNewCustomer.Equals(Constants.Edit) 
                && _customerViewModel.CurrentCustomer != null)
                this.UpdateCustomer(_customerViewModel.CurrentCustomer);
        }

        private void CreateNewCustomer(Customer customer)
        {
            CreateCustomersClass createCustomer = new CreateCustomersClass(null);
            createCustomer.AddItem(customer);
            createCustomer.SaveCreatedItems();
        }

        private void UpdateCustomer(Customer customer)
        {
            UpdateCustomerClass updateCustomer = new UpdateCustomerClass(customer);
            updateCustomer.SaveUpdate();
        }
    }
}