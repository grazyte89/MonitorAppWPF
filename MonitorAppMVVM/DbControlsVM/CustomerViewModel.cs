using PetsEntityLib.DataBaseExtractions;
using PetsEntityLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonitorAppMVVM.DbControlsVM
{
    public class CustomerViewModel
    {
        private IList<Customer> _customerList;
        private RetrieveCustomerButton _btnRetrieveCustomer;

        public bool CustomerListAccessEnabled { get; set; }

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

        public CustomerViewModel()
        {
            _btnRetrieveCustomer = new RetrieveCustomerButton(this);
            _customerList = RetrieveCustomers.GetAllCustomers();

            CustomerListAccessEnabled = true;
        }
    }
}
