using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityMvcApp.BLL;
using UniversityMvcApp.Models;


namespace UniversityMvcApp.Controllers
{
    public class TeacherCourseAssignController : Controller
    {
        private UniversityDbContext db = new UniversityDbContext();
        DepartmentManager aDepartmentManager=new DepartmentManager();
        TeacherManager aTeacherManager= new TeacherManager();
        CourseManager aCoursemanager = new CourseManager();
        //
        // GET: /TeacherCourseAssign/
        public ActionResult AssignCourse()
        {
            ViewBag.Departments = aDepartmentManager.GetDepartments();
            return View();
        }
        [HttpPost]
        public ActionResult AssignCourse(Course Courses)
        {
            ViewBag.Departments = aDepartmentManager.GetDepartments();
            if(!aCoursemanager.IsCourseAssign(Courses.Id))
            {
                bool message = aCoursemanager.AssignTeacher(Courses);
                if (message)
                {
                    ViewBag.message="Successfully Course Assigned!";
                }
                else
                {
                     ViewBag.message="Course Assign Failed!";
                }
            }
            else
            {
                ViewBag.error="This Course Has Already Assigned To a Teacher";
            }
            return View();
        }
        public JsonResult GetTeacherByDepartmentId(int departmentId)
        {
            List<Teacher> teachers = aTeacherManager.GetTeachers();
            var teacherList = teachers.Where(a => a.DepartmentId == departmentId).ToList();
            return Json(teacherList);
        }


      

        public JsonResult GetDepartmentByDepartmentId(int departmentId)
        {
            List<Department> departments = aDepartmentManager.GetAllDepartments();
            var department = departments.Find(a => a.ID == departmentId);
            return Json(department);
        }

        public JsonResult GetTeacherByTeacherId(int teacherId)
        {
            List<Teacher> teachers = aTeacherManager.GetTeachers();
            var teacher = teachers.Find(a => a.ID ==teacherId);
            List<Course> courses = aCoursemanager.GetAllCourses();
            var coursesofTeacher = courses.Where(a =>a.TeacherId == teacherId).ToList();
            teacher.CreditTaken = 0;
            foreach (var course in coursesofTeacher)
            {
                teacher.CreditTaken += course.Credit;
            }
            teacher.RemainingCredit = teacher.CreditToBeTaken - teacher.CreditTaken;
            return Json(teacher);
        }
        public JsonResult GetCourseByCourseId(int CourseId)
        {
          
            List<Course> courses = aCoursemanager.GetAllCourses();
            var course = courses.Find(a => a.Id == CourseId);
            return Json(course);
        }
        public JsonResult GetCourseIdByDepartmentId(int DepartmentId)
        {

            List<Course> courses = aCoursemanager.GetAllCourses();
            var course = courses.Where(a => a.DepartmentId == DepartmentId).ToList();
            return Json(course);
        }
       
       
	}
}