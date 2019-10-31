using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityMvcApp.BLL;
using UniversityMvcApp.Models;

namespace UniversityMvcApp.Controllers
{
    public class ViewCourseStaticsController : Controller
    {
        ViewCourseStaticsManager aViewCourseStaticsManager = new ViewCourseStaticsManager();
        DepartmentManager departmentManager = new DepartmentManager();
        CourseManager aCourseManager = new CourseManager();
        // GET: ViewCourseStatics
        public ActionResult Index()
        {
            ViewBag.departments = departmentManager.GetDepartments();
            return View();
        }
        [HttpPost]
        public ActionResult Index(Department department)
        {
            ViewBag.departments = departmentManager.GetDepartments();
            return View();
        }
        public JsonResult GetCourseStaticsByDepartment(int departmentId)
        {
            //List<Course> course = db.Courses.ToList();

            List<Course> courses = aCourseManager.GetAllCourses();
            var course = courses.Where(a => a.DepartmentId == departmentId).ToList();
            List<ViewCourseStatics> viewCourseStatics = new List<ViewCourseStatics>();
            foreach (var course1 in course)
            {
                if(course1.TeacherId==0)
                {
                    ViewCourseStatics aViewCourseStatic = new ViewCourseStatics();
                    aViewCourseStatic.Name = course1.Name;
                    aViewCourseStatic.Code = course1.Code;
                    aViewCourseStatic.AssignedTo = "Not Assign Yet!";
                    aViewCourseStatic.SemesterId = course1.SemesterId;
                    viewCourseStatics.Add(aViewCourseStatic);
                }
                else
                {
                    viewCourseStatics.Add(aViewCourseStaticsManager.GetView(course1));
                }
              
            }

            return Json(viewCourseStatics);
            //return Json(courses, JsonRequestBehavior.AllowGet);
        }
    }
}