using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityMvcApp.DAL.Gateway;
using UniversityMvcApp.Models;

namespace UniversityMvcApp.BLL
{
    public class ViewClassScheduleWithRoomAllocationsManager
    {
        ViewClassScheduleWithRoomAllocationsGateway aViewClassScheduleWithRoomAllocationsGateway = new ViewClassScheduleWithRoomAllocationsGateway();

        public ViewClassScheduleWithRoomAllocation GetView(Course course)
        {
            return aViewClassScheduleWithRoomAllocationsGateway.GetView(course);
        }

        public ViewClassScheduleWithRoomAllocation GetView2(Subject subject)
        {
            return aViewClassScheduleWithRoomAllocationsGateway.GetView2(subject);
        }
    }
}