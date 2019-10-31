using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityMvcApp.Models
{
    public class EnrollCourses
    {
        public int Id { get; set; }

        public string DepartmentName { get; set;  }
        

        public int CourseId { get; set; }
        public Course course { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public string StudentSerialNum { get; set; }
       
        
        public int SubjectID { get; set; }
        public Subject Subject { get; set; }

        public string Grade { get; set; }

        public DateTime date { get; set; }


    }
}