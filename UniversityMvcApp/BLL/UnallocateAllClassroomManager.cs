using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityMvcApp.DAL.Gateway;

namespace UniversityMvcApp.BLL
{
    public class UnallocateAllClassroomManager
    {
        UnallocateAllClassroomGateway aUnallocateAllClassroomGateway = new UnallocateAllClassroomGateway();
        public bool UpdateCourses()
        {
            return aUnallocateAllClassroomGateway.UpdateCourses();
        }
    }
}