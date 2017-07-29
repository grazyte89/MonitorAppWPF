using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsEntityLib.Entities
{
    public class JoinCustomerCourse : IEntityDaBase
    {
        public int ID { get; set; }
        public int CUSTOMER_ID { get; set; }
        public int COURSE_ID { get; set; }

        [ForeignKey("CUSTOMER_ID")]
        public Customer Customer { get; set; }
        [ForeignKey("COURSE_ID")]
        public Course Course { get; set; }
    }
}
