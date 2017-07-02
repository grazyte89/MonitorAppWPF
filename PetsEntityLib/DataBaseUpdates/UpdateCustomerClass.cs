using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetsEntityLib.Entities;

namespace PetsEntityLib.DataBaseUpdates
{
    public class UpdateCustomerClass : IDBUpdate
    {
        private Customer customer;

        public UpdateCustomerClass(Customer customer)
        {
            this.customer = customer;
        }

        public void SaveUpdate()
        {
            throw new NotImplementedException();
        }
    }
}
