using System;
using System.Collections.Generic;
using System.Linq;
using Rotativa;
using System.Web;
using System.Web.Mvc;
using UniversityMvcApp.BLL;
using UniversityMvcApp.Models;


namespace UniversityMvcApp.Areas.TeacherArea.Controllers
{

    public class ViewResult3Controller : Controller
    {
        private UniversityDbContext db = new UniversityDbContext();
        ViewResultManager viewResultManager = new ViewResultManager();
        EnrollCourseManager enrollCourseManager = new EnrollCourseManager();
        // GET: EnrollCourses
        public ActionResult ResultView()
        {
            ViewBag.StudentId = db.Students.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult ResultView(EnrollCourses enrollCourse)
        {
            ViewBag.StudentId = db.Students.ToList();



            return View();


        }
        public ActionResult ResultPdf(EnrollCourses enrollCourse)
        {
            List<Student> students = db.Students.ToList();
            Student student = students.Find(a => a.Id == enrollCourse.StudentId);
            List<ResultView> aResultViews = viewResultManager.GetResultOfStudent(enrollCourse.StudentId);
            ViewBag.Result = aResultViews;
            ViewBag.StudentId = student.RegistrationSerial;
            return View();
        }

        public ActionResult UrlAsPDF(EnrollCourses enrollCourse)
        {
            return new ActionAsPdf("ResultPdf", enrollCourse) { FileName = "Result.pdf" };
        }


        public JsonResult GetStudentByStudentId(int studentId)
        {
            //List<Course> course = db.Courses.ToList();


            //var students = db.Students.ToList();
            //var student = students.Find(a => a.Id == studentId);
            //List<Course> courses = db.Courses.ToList();
            Student student = enrollCourseManager.SearchStudentById(studentId);
            string Name = student.Name;
            //return Json(course);
            return Json(Name, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDepartmentNameByStudentId(int studentId)
        {
            Student student = enrollCourseManager.SearchStudentById(studentId);
            Department Department = enrollCourseManager.SearchDepartmentStudentById(student.DepartmentId);
            string Name = Department.Name;
            //return Json(course);
            return Json(Name, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetResultTableByStudent(int studentId)
        {
            //List<Course> course = db.Courses.ToList();


            List<ResultView> aResultViews = viewResultManager.GetResultOfStudent(studentId);


            return Json(aResultViews);
            //return Json(courses, JsonRequestBehavior.AllowGet);
        }

    }

}



