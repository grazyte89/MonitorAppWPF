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

        public bool DeleteItems(out string message)
        {
            message = string.Empty;
            try
            {
                using (PetShopDBContext _dbContext = new PetShopDBContext())
                {
                    if (_joinCustomerCourseToDelete != null && _joinCustomerCourseToDelete.Count > 0)
                    {
                        _dbContext.JoinCustomerCourses.RemoveRange(_joinCustomerCourseToDelete);
                        _dbContext.SaveChanges();
                        _joinCustomerCourseToDelete.Clear();
                    }
                }
                message = "Deletion Successful";
                return true;
            }
            catch (Exception exception)
            {
                message = "Problem encountered during deleting joincustomercourse." +
                    "Message" + exception.Message;
                return false;
            }
        }
    }
}
