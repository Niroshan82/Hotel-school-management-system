using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityMvcApp.Models
{
    public class EnrollCoursesBasic
    {
        public int Id { get; set; }

        public string DepartmentName { get; set; }
       

        public int CourseId { get; set; }
        public Course course { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public string StudentSerialNum { get; set; }

        public DateTime date { get; set; }
    }
}