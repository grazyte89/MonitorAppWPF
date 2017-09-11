using PetsEntityLib.DataBaseContext;
using PetsEntityLib.Entities;
using System;
using System.Collections.Generic;
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
                _coursesToDelete = coursesToDelete;
            else
                _coursesToDelete = new List<Course>();
        }

        public DeleteCourseClass(Course course)
        {
            _coursesToDelete = new List<Course>();
            if (course != null)
                _coursesToDelete.Add(course);
        }

        public void AddItemForDeletion(Course value)
        {
            if (value != null)
                _coursesToDelete.Add(value);
        }

        public void DeleteItems()
        {
            try
            {
                using (PetShopDBContext _dbContext = new PetShopDBContext())
                {
                    if (_coursesToDelete != null && _coursesToDelete.Count > 0)
                    {
                        _dbContext.Courses.RemoveRange(_coursesToDelete);
                        _dbContext.SaveChanges();
                        _coursesToDelete.Clear();
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Problem encountered during deleting courses." +
                    "Message" + exception.Message);
            }
        }
    }
}
