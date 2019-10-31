using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityMvcApp.BLL;
using UniversityMvcApp.Models;

namespace UniversityMvcApp.Controllers
{
    public class UnallocateAllClassroomController : Controller
    {
        UnallocateAllClassroomManager aUnallocateAllClassroomManager = new UnallocateAllClassroomManager();
        // GET: UnallocateAllClassroom
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(AllocateClassRoom allocateclassRoom)
        {
            if (aUnallocateAllClassroomManager.UpdateCourses())
            {
                ViewBag.Successmessge = "All the ClassRooms are Successfully unallocated!";
            }

            return View();
        }
    }
}