using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PetsEntityLib.Entities
{
    /* Entity framework would automatically think that the name in
     * the database is pural, and hence it look for the table named
     * 'JoinCustomerCourses', which does not exist, and would throw
     * error saying invalid object name dbo.JoinCustomerCourses.
     * 
     * By adding the 'Table' atrribute, we tell entity to look for
     * this table.
     * */
    [DataContract(Name = "JoinCustomerCourse")]
    [Table("JoinCustomerCourse")]
    public class JoinCustomerCourse : IEntityDaBase
    {
        [DataMember(Name = "ID")]
        [Key, Column(Order = 0)]
        public int ID { get; set; }

        [DataMember(Name = "CUSTOMER_ID")]
        [Key, Column(Order = 1), ForeignKey("Customer")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CUSTOMER_ID { get; set; }

        [DataMember(Name = "COURSE_ID")]
        [Key, Column(Order = 2), ForeignKey("Course")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int COURSE_ID { get; set; }

        [DataMember(Name = "Customer")]
        [ForeignKey("CUSTOMER_ID")]
        public Customer Customer { get; set; }

        [DataMember(Name = "Course")]
        [ForeignKey("COURSE_ID")]
        public Course Course { get; set; }
    }
}
