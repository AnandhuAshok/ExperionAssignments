using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    public class Students
    {
        internal bool flag;

        public int StudentId { get; set; }

        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }

        [StringLength(25)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        internal object OrderByDescending(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        [StringLength(2000)]
        public string Address { get; set; }

        [Required]
        [Phone]
        public string PhoneNo { get; set; }
        public string Course { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]


        public DateTime EnrollmentDate { get; set; }

    }
}
