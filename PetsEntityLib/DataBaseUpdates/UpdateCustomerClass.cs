using System;
using System.Collections.Generic;
using System.Linq;
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

                this.AddAllNewItems(_dbcontext);
                _dbcontext.Entry(_currentCustomer).State = EntityState.Modified;
                this.UpdateAllNavigationEntities(_dbcontext);
                
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
                _dbcontext.SaveChanges();
            }
        }

        private void AddAllNewItems(PetShopDBContext dbcontext)
        {
            if (_currentCustomer.Messages != null && _currentCustomer.Messages.Count > 0)
                dbcontext.AddNewItems<Message>(_currentCustomer.Messages, m => m.ID == 0);
                //this.AddNewMessages(dbContext);
        }

        private void AddNewMessages(PetShopDBContext dbContext)
        {
            var newMessages = _currentCustomer.Messages
                                .Where(m => m.ID == 0).ToList();
            foreach (var item in newMessages)
                dbContext.Entry(item).State = EntityState.Added;
        }

        private void UpdateAllNavigationEntities(PetShopDBContext dbcontext)
        {
            if (_currentCustomer.Messages != null && _currentCustomer.Messages.Count > 0)
                this.UpdateMessages(dbcontext);
            if (_currentCustomer.Courses != null && _currentCustomer.Courses.Count > 0)
                this.UpdateCourses(dbcontext);
        }

        private void UpdateCourses(PetShopDBContext dbContext)
        {
            var detatchedCollection = this.GetDetatchedCollection<JoinCustomerCourse>(dbContext, 
                                        _currentCustomer.Courses, c => c.Courses, true);

            foreach (var item in detatchedCollection)
            {
                var existingData = dbContext.JoinCustomerCourses
                            .FirstOrDefault(x => x.CUSTOMER_ID == item.CUSTOMER_ID
                            && x.COURSE_ID == item.COURSE_ID);
                dbContext.Entry(item).State = existingData != null ? EntityState.Modified : EntityState.Added;
            }

            _currentCustomer.Courses = detatchedCollection;
        }

        private void UpdateMessages(PetShopDBContext dbContext)
        {
            var detatchedCollection = this.GetDetatchedCollection<Message>(dbContext,
                                        _currentCustomer.Messages, c => c.Messages, false);

            // dbcontext.Entry(_currentCustomer).State = EntityState.Modified;
            /* When tagging child entities in a collection as Entitystate.Modified,
             * make sure you tag the parent entity as Modified, or else it will throw
             * am error.
             * */
            var existingMessages = detatchedCollection.Where(m => m.ID > 0)
                                    .ToList();
            foreach (var item in existingMessages)
                dbContext.Entry(item).State = EntityState.Modified;

            _currentCustomer.Messages = detatchedCollection;
        }

        private List<TEntity> GetDetatchedCollection<TEntity>(PetShopDBContext dbcontext, ICollection<TEntity> collection,
            Expression<Func<Customer, ICollection<TEntity>>> loadFunction, bool loadPrevious) where TEntity : class
        {
            if (!loadPrevious)
                return collection.ToList();

            var detatchedCollection = collection.ToList();
            dbcontext.Entry(_currentCustomer).Collection(loadFunction).Load();
            collection.Clear();
            return detatchedCollection;
        }
    }
}
