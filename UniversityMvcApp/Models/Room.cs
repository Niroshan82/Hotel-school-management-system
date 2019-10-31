using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityMvcApp.Models
{
    public class Room
    {
        public int Id { get; set; }

        public string RoomNo { get; set; }

        public int? DepartmentId { get; set; }

        public Department Department { get; set; }

        public virtual List<AllocateClassRoom> AllocateClassRooms { get; set; }
    }
}