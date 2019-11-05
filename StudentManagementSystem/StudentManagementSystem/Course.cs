using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    public class Course
    {

        [Required]
        [StringLength(255)]
        public String CourseName { get; set; }
        public String Sub1 { get; set; }
        public String Sub2 { get; set; }
        public String Sub3 { get; set; }

    }
}
