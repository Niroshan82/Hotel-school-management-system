using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityMvcApp.DAL.Gateway;

namespace UniversityMvcApp.BLL
{
    public class ViewCourseStaticsManager
    {
        ViewCourseStaticsGateway aViewCourseStaticsGateway = new ViewCourseStaticsGateway();
        public Models.ViewCourseStatics GetView(Models.Course course1)
        {
            return aViewCourseStaticsGateway.GetView(course1);
        }
    }
}