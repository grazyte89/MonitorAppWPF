using PetsEntityLib.DataBaseContext;
using PetsEntityLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetsEntityLib.DataBasePersistances
{
    public class CreateCourseClass : IDBPersistance<Course>
    {
        private IList<Course> _courses;

        public CreateCourseClass(IList<Course> courses)
        {
            if (courses != null)
                _courses = courses;
            else
                _courses = new List<Course>();
        }

        public IList<Course> Courses
        {
            get
            {
                return _courses;
            }
        }

        public CreateCourseClass(string name, string subjectType)
        {
            _courses.Add(new Course
            {
                NAME = name,
                SUBJECT_TYPE = subjectType
            });
        }

        public void AddItem(Course value)
        {
            if (value != null)
                _courses.Add(value);
        }

        public void SaveCreatedItems()
        {
            try
            {
                using (PetShopDBContext _dbContext = new PetShopDBContext())
                {
                    if (_courses != null && _courses.Count > 0)
                    {
                        _dbContext.Courses.AddRange(_courses);
                        _dbContext.SaveChanges();
                        _courses.Clear();
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Problem encountered during persisting course." +
                    "Message" + exception.Message);
            }
        }
    }
}
