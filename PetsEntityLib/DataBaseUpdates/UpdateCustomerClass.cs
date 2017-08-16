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
                {
                    var itn = _currentCustomer.Courses.Select(x => x.COURSE_ID).ToList();
                    this.UpdateCollection(_dbcontext, c => c.Courses, _currentCustomer.Courses,
                        x => x.ID == 0, x => x.ID > 0);
                }

                _dbcontext.SaveChanges();
            }
        }

        private void UpdateCollection<T>(DbContext dbcontext, Expression<Func<Customer, ICollection<T>>> collectionProperty, 
            ICollection<T> collection, Expression<Func<T, bool>> existingEquation, Expression<Func<T, bool>> newEquation) where T : class
        {
            dbcontext.Entry(_currentCustomer).Collection(collectionProperty).Load();
            var existingItems = collection.AsQueryable().Where(existingEquation).ToList();
            var newItems = collection.AsQueryable().Where(newEquation).ToList();
            foreach (var item in existingItems)
                dbcontext.Entry(item).State = EntityState.Unchanged;
            foreach (var item in newItems)
                dbcontext.Entry(item).State = EntityState.Added;
            //var genericEnity = dbcontext.Set<T>();
            //var itemsRetreived = genericEnity.Where(col).ToList();
            //collection = itemsOj;
        }

        private void UpdateManyToManyCollection()
        {

        }
    }
}
