using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityMvcApp.DAL.Gateway;

namespace UniversityMvcApp.BLL
{
    public class UnassignAllCoursesManager
    {
        UnassignAllCoursesGateway aUnassignAllCoursesGateway = new UnassignAllCoursesGateway();
        public bool UpdateCourses()
        {
            return aUnassignAllCoursesGateway.UpdateCourses();
        }
    }
}