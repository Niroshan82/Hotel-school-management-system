using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityMvcApp.DAL.Gateway;
using UniversityMvcApp.Models;

namespace UniversityMvcApp.BLL
{
    public class AllocateClassRoomManager
    {
        static AllocateClassRoomGateway allocateClassRoomGateway = new AllocateClassRoomGateway();
        CourseGateway aCourseGateway = new CourseGateway();

        public bool IsTimeAlocated(AllocateClassRoom allocateClassRoom)
        {
            return allocateClassRoomGateway.IsTimeAlocated(allocateClassRoom);
        }

        public List<Course> GetCourseByDepartmentId()
        {
            return aCourseGateway.GetAllCourses();
        }

        public List<Subject> GetSubjectByDepartmentId()
        {
            return aCourseGateway.GetAllSubjects();
        }

        public static bool HasClass(AllocateClassRoom allocateClassRoom)
        {
            return allocateClassRoomGateway.HasClass(allocateClassRoom);

        }

        public List<Models.Course> GetAllCourses()
        {
            return aCourseGateway.GetAllCourses();
        }
    }
}