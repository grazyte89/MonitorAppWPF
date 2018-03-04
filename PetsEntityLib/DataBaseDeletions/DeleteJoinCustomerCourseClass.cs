using PetsEntityLib.DataBaseContext;
using PetsEntityLib.Entities;
using PetsEntityLib.PetsExceptions;
using PetsEntityLib.EntityExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetsEntityLib.DataBaseDeletions
{
    public class DeleteJoinCustomerCourseClass : IDBDeletion<JoinCustomerCourse>
    {
        private IList<JoinCustomerCourse> _joinCustomerCourseToDelete;

        public DeleteJoinCustomerCourseClass(IList<JoinCustomerCourse> joinCustomerCourseToDelete)
        {
            if (joinCustomerCourseToDelete != null)
            {
                _joinCustomerCourseToDelete = joinCustomerCourseToDelete;
            }
            else
            {
                _joinCustomerCourseToDelete = new List<JoinCustomerCourse>();
            }
        }

        public DeleteJoinCustomerCourseClass(JoinCustomerCourse joinCustomerCourse)
        {
            _joinCustomerCourseToDelete = new List<JoinCustomerCourse>();
            if (joinCustomerCourse != null)
            {
                _joinCustomerCourseToDelete.Add(joinCustomerCourse);
            }
        }

        public void AddItemForDeletion(JoinCustomerCourse value)
        {
            if (value != null)
            {
                _joinCustomerCourseToDelete.Add(value);
            }
        }

        public void DeleteItems()
        {
            if (_joinCustomerCourseToDelete == null || _joinCustomerCourseToDelete.Count > 0)
            {
                var reason = _joinCustomerCourseToDelete == null
                        ? "null" : "equal or less than zero";
                var message = string.Format("Deletion could not be executed " +
                        "because to the internal list being {0}", reason);
                throw new PetsEntityException(message);
            }

            try
            {
                using (PetShopDBContext _dbContext = new PetShopDBContext())
                {
                    //_dbContext.JoinCustomerCourses.RemoveRange(_joinCustomerCourseToDelete);
                    _dbContext.TagEntitiesAsDeleted<JoinCustomerCourse>(_joinCustomerCourseToDelete);
                    _dbContext.SaveChanges();
                    _joinCustomerCourseToDelete.Clear();
                }
            }
            catch (Exception exception)
            {
                // logging here
                throw;
            }
        }
    }
}
