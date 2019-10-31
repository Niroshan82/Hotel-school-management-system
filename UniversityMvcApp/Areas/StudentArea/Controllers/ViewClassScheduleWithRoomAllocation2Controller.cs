using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityMvcApp.BLL;
using UniversityMvcApp.Models;

namespace UniversityMvcApp.Areas.StudentArea.Controllers
{
    public class ViewClassScheduleWithRoomAllocation2Controller : Controller
    {
        ViewClassScheduleWithRoomAllocationsManager viewClassScheduleWithRoomAllocationsManager = new ViewClassScheduleWithRoomAllocationsManager();
        DepartmentManager departmentManager = new DepartmentManager();
        CourseManager aCourseManager = new CourseManager();
        // GET: ViewClassScheduleWithRoomAllocation
        AllocateClassRoomManager allocateClassroomManager = new AllocateClassRoomManager();

        public ActionResult ViewCourseDetails()
        {
            ViewBag.departments = departmentManager.GetDepartments();

            return View();
        }
        [HttpPost]
        public ActionResult ViewCourseDetails(Department department)
        {
            ViewBag.departments = departmentManager.GetDepartments();

            return View();
        }
        public JsonResult GetCourseTableByDepartment(int departmentId)
        {
            //List<Course> course = db.Courses.ToList();

            List<Course> courses = aCourseManager.GetAllCourses();
            var course = courses.Where(a => a.DepartmentId == departmentId).ToList();
            List<ViewClassScheduleWithRoomAllocation> viewClassScheduleWithRoomAllocations = new List<ViewClassScheduleWithRoomAllocation>();
            foreach (var course1 in course)
            {
                viewClassScheduleWithRoomAllocations.Add(viewClassScheduleWithRoomAllocationsManager.GetView(course1));
            }

            return Json(viewClassScheduleWithRoomAllocations);
            //return Json(courses, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetSubjectTableByDepartment(int departmentId)
        {
            //  List<Subject> course = db.Courses.ToList();

            List<Subject> subjects = aCourseManager.GetAllSubjects();
            var subject = subjects.Where(a => a.DepartmentId == departmentId).ToList();
            List<ViewClassScheduleWithRoomAllocation> viewClassScheduleWithRoomAllocations = new List<ViewClassScheduleWithRoomAllocation>();
            foreach (var subject1 in subject)
            {
                viewClassScheduleWithRoomAllocations.Add(viewClassScheduleWithRoomAllocationsManager.GetView2(subject1));
            }

            return Json(viewClassScheduleWithRoomAllocations);
            //return Json(courses, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSubjectByCourseId(int CourseId)
        {
            //List<Course> course = db.Courses.ToList();

            List<Subject> subjects = allocateClassroomManager.GetSubjectByDepartmentId();
            var Subjects = subjects.Where(a => a.SubCourForId == CourseId).ToList();
            return Json(Subjects);
            //return Json(courses, JsonRequestBehavior.AllowGet);
        }



    }
}