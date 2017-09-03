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

                if (_currentCustomer.Messages != null && _currentCustomer.Messages.Count > 0)
                    this.UpdateMessages(_dbcontext);

                _dbcontext.Entry(_currentCustomer).State = EntityState.Modified;
                
                /* Before a parent entity is tagged as medified, make sure all new
                 * child entity objects in its collection are tagged as Entitysate.Added,
                 * if the relationship is a one-to-many.
                 * Because if not, it will throw an error, either saying foreign
                 * key property does not match or something like duplicate id.
                 * 
                 * The reason why it throws an error is because, the child entities
                 * at that point in time are tagged as Entitysate.Unchanged.
                 * So when we mark the parent entities as Modified, entity looks
                 * through its collection and will find new entity objects whose
                 * foreign key id has not be assigned.
                 * Or, if the foreign key property is assigned, it will think that
                 * the parent entity is new, which in this case will throw an error
                 * because entity knows there is an enitity object with the same id.  
                 * */

                if (_currentCustomer.Courses != null && _currentCustomer.Courses.Count > 0)
                    this.UpdateCourses(_dbcontext);

                _dbcontext.SaveChanges();
            }
        }

        private List<TEntity> GetDetatchedCollection<TEntity>(DbContext dbcontext, ICollection<TEntity> collection, 
            Expression<Func<Customer, ICollection<TEntity>>> loadFunction, bool loadPrevious) where TEntity : class
        {
            if (!loadPrevious)
                return collection.ToList();

            var detatchedCollection = collection.ToList();
            dbcontext.Entry(_currentCustomer).Collection(loadFunction).Load();
            collection.Clear();
            return detatchedCollection;
        }

        private void AssignEntityStateTags(DbContext dbContext, IEntityDaBase entityObject, bool existingObject)
        {
            if (existingObject)
                dbContext.Entry(entityObject).State = EntityState.Modified;
            else
                dbContext.Entry(entityObject).State = EntityState.Added;
        }

        private void UpdateCourses(PetShopDBContext dbcontext)
        {
            var detatchedCollection = this.GetDetatchedCollection<JoinCustomerCourse>(dbcontext, 
                                        _currentCustomer.Courses, c => c.Courses, true);

            foreach (var item in detatchedCollection)
            {
                var existingData = dbcontext.JoinCustomerCourses
                            .FirstOrDefault(x => x.CUSTOMER_ID == item.CUSTOMER_ID
                            && x.COURSE_ID == item.COURSE_ID);
                this.AssignEntityStateTags(dbcontext, item, existingData != null);
            }

            _currentCustomer.Courses = detatchedCollection;
        }

        private void UpdateMessages(PetShopDBContext dbcontext)
        {
            var detatchedCollection = this.GetDetatchedCollection<Message>(dbcontext,
                                        _currentCustomer.Messages, c => c.Messages, false);
            var newMessages = detatchedCollection.Where(m => m.ID == 0)
                                .ToList();
            var existingMessages = detatchedCollection.Where(m => m.ID > 0)
                                .ToList();

            foreach (var item in newMessages)
                this.AssignEntityStateTags(dbcontext, item, false);

            if (dbcontext.Entry(_currentCustomer).State != EntityState.Modified)
            {
                dbcontext.Entry(_currentCustomer).State = EntityState.Modified;
            }
            foreach (var item in existingMessages)
                this.AssignEntityStateTags(dbcontext, item, true);

            /* When tagging child entities in a collection as Entitystate.Modified,
             * make sure you tag the parent entity as Modified, or else it will throw
             * am error.
             * */

            _currentCustomer.Messages = detatchedCollection;
        }

        /*private void UpdateCourses(PetShopDBContext dbcontext)
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
        }*/

        /*private void UpdateMessages(PetShopDBContext dbcontext)
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
        }*/
    }
}
