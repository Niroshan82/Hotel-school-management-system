using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityMvcApp.Models
{
    public class ViewClassScheduleWithRoomAllocation
    {
        public int? DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public string CourseName { get; set; }

        public string ScheduleInfo { get; set; }

        public string SubjectCode { get; set; }

        public string SubjectName { get; set; }
    }
}