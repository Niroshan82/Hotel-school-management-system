using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityMvcApp.Models
{
    public class Semester
    {
        public int ID { get; set; }
        public int SemesterNumber { get; set; }

        public virtual List<Course> Courses { get; set; } 
    }
}