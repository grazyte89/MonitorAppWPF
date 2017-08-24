using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetsEntityLib.Entities;
using PetsEntityLib.DataBaseContext;
using System.Data.Entity;
using System.Linq.Expressions;

namespace PetsEntityLib.DataBaseUpdates
{
    public class UpdateCustomerClass : IDBUpdate
    {
        private Customer _currentCustomer;

        public UpdateCustomerClass(Customer customer)
        {
            this._currentCustomer = customer;
        }

        public void SaveUpdate()
        {
            using (PetShopDBContext _dbcontext = new PetShopDBContext())
            {
                if (_currentCustomer == null)
                    return;
                _dbcontext.Entry(_currentCustomer).State = EntityState.Modified;

                if (_currentCustomer.Courses != null && _currentCustomer.Courses.Count > 0)
                    this.UpdateCourses(_dbcontext);
                if (_currentCustomer.Messages != null && _currentCustomer.Messages.Count > 0)
                    this.UpdateMessages(_dbcontext);

                _dbcontext.SaveChanges();
            }
        }

        private void UpdateCourses(PetShopDBContext dbcontext)
        {
            var detatchedCollection = _currentCustomer.Courses.ToList();
            dbcontext.Entry(_currentCustomer).Collection(dc => dc.Courses).Load();
            _currentCustomer.Courses.Clear();

            foreach (var item in detatchedCollection)
            {
                var existingData = dbcontext.JoinCustomerCourses
                            .FirstOrDefault(x => x.CUSTOMER_ID == item.CUSTOMER_ID
                            && x.COURSE_ID == item.COURSE_ID);
                if (existingData != null)
                    dbcontext.Entry(item).State = EntityState.Modified;
                else
                    dbcontext.Entry(item).State = EntityState.Added;
            }

            _currentCustomer.Courses = detatchedCollection;
        }

        private void UpdateMessages(PetShopDBContext dbcontext)
        {
            var detatchedCollection = _currentCustomer.Messages.ToList();
            dbcontext.Entry(_currentCustomer).Collection(dc => dc.Messages).Load();
            _currentCustomer.Messages.Clear();

            foreach (var item in detatchedCollection)
            {
                var existingItem = dbcontext.Messages
                            .FirstOrDefault(x => x.ID == item.ID);
                if (existingItem != null)
                    dbcontext.Entry(item).State = EntityState.Modified;
                else
                    dbcontext.Entry(item).State = EntityState.Added;
            }

            _currentCustomer.Messages = detatchedCollection;
        }
    }
}
