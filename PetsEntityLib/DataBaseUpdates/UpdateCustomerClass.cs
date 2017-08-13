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
                        itn, x => itn.Contains(x.COURSE_ID));
                }

                _dbcontext.SaveChanges();
            }
        }

        private void UpdateCollection<T>(DbContext dbcontext, Expression<Func<Customer, ICollection<T>>> collectionProperty, 
            ICollection<T> collection, ICollection<int> ids, Expression<Func<T, bool>> col) where T : class
        {
            //var temp = collection.ToList();
            collection.Clear();
            var gndet = dbcontext.Set<T>().Where(col);
            dbcontext.Entry(_currentCustomer).Collection(collectionProperty).Load();
            collection = gndet.ToList();
        }
    }
}
