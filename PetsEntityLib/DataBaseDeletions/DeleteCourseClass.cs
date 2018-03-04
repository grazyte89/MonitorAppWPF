using PetsEntityLib.DataBaseContext;
using PetsEntityLib.Entities;
using PetsEntityLib.PetsExceptions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetsEntityLib.DataBaseDeletions
{
    public class DeleteCourseClass : IDBDeletion<Course>
    {
        private IList<Course> _coursesToDelete;

        public DeleteCourseClass(IList<Course> coursesToDelete)
        {
            if (coursesToDelete != null)
            {
                _coursesToDelete = coursesToDelete;
            }
            else
            {
                _coursesToDelete = new List<Course>();
            }
        }

        public DeleteCourseClass(Course course)
        {
            _coursesToDelete = new List<Course>();
            if (course != null)
            {
                _coursesToDelete.Add(course);
            }
        }

        public void AddItemForDeletion(Course value)
        {
            if (value != null)
            {
                _coursesToDelete.Add(value);
            }
        }

        public void DeleteItems()
        {
            if (_coursesToDelete == null || _coursesToDelete.Count <= 0)
            {
                var reason = _coursesToDelete == null
                        ? "null" : "equal or less than zero";
                var message = string.Format("Deletion could not be executed " +
                        "because to the internal list being {0}", reason);
                throw new PetsEntityException(message);
            }

            try
            {
                using (PetShopDBContext _dbContext = new PetShopDBContext())
                {
                    //_dbContext.Courses.RemoveRange(_coursesToDelete);
                    this.TagEntitiesAsDeleted(_dbContext);
                    _dbContext.SaveChanges();
                    _coursesToDelete.Clear();
                }
            }
            catch (Exception exception)
            {
                // logging here
                throw;
            }
        }

        private void TagEntitiesAsDeleted(PetShopDBContext dbContext)
        {
            foreach (var item in _coursesToDelete)
            {
                dbContext.Entry(item).State = EntityState.Deleted;
            }
        }
    }
}
