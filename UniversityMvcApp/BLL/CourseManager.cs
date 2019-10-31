using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityMvcApp.DAL.Gateway;

namespace UniversityMvcApp.BLL
{
    public class CourseManager
    {
        CourseGateway aCourseGateway=new CourseGateway();

        public bool IsCodeExist(string code)
        {
            if (aCourseGateway.IsCodeExist(code))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

       public bool IsNameExist(string name)
        {
            if (aCourseGateway.IsNameExist(name))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

       public List<Models.Course> GetAllCourses()
       {
           return aCourseGateway.GetAllCourses();
       }

        public List<Models.Subject> GetAllSubjects()
        {
            return aCourseGateway.GetAllSubjects();
        }


        public bool IsCourseAssign(int courseId)
       {
           return aCourseGateway.IsCourseAssign(courseId);
       }

       public bool AssignTeacher(Models.Course Courses)
       {
           return aCourseGateway.AssignTeacher(Courses);
       }
    }
}