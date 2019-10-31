using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityMvcApp.BLL;
using UniversityMvcApp.Models;

namespace UniversityMvcApp.Controllers
{
    public class UnassignAllCoursesController : Controller
    {
        private UniversityDbContext db = new UniversityDbContext();
        UnassignAllCoursesManager aUnassignAllCoursesManager = new UnassignAllCoursesManager();
        // GET: UnassignAllCourses
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Course courses)
        {
          if(aUnassignAllCoursesManager.UpdateCourses())
          {
              ViewBag.Successmessge = "All the courses are Successfully unassigned!";
          }
         
            return View();
        }
    }
}