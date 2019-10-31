using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityMvcApp.Models
{
    public class ResultView
    {
        public string CourseCode { get; set; }
        public string Name { get; set; }
        public string SubjectCode { set; get; }
        public string SubjectName { set; get; }

        public string Grade { get; set; }
    }
}