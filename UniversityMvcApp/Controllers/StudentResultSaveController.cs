using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityMvcApp.BLL;
using UniversityMvcApp.DAL.Gateway;
using UniversityMvcApp.Models;

namespace UniversityMvcApp.Controllers
{
    public class StudentResultSaveController : Controller
    {
        private UniversityDbContext db = new UniversityDbContext();
        EnrollCourseManager enrollCourseManager = new EnrollCourseManager();
        // GET: EnrollCourses
        public ActionResult Save()
        {
            ViewBag.StudentId = db.Students.ToList();
            ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "Name");
            return View();
        }
        //[HttpPost]
        //public ActionResult Save(EnrollCourses enrollCourse)
        //{
        //    ViewBag.StudentId = db.Students.ToList();
        //    ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "Name");

        //    if (ModelState.IsValid)
        //    {
        //        //db.EnrollCourses.SqlQuery("Update EnrollCourses SET Grade='"+enrollCourse.Grade+"' Where CourseId='"+enrollCourse.CourseId+"'");
        //        if (enrollCourseManager.UpdateEnrollCourse(enrollCourse))
        //        {
        //            ViewBag.saveMessage = "Student Result Add Successfully!";
        //        }
        //        else
        //        {
        //            ViewBag.saveMessage = "Student Result Not Save!";
        //        }


        //    }

        //    return View();
        //}


        [HttpPost]
        public ActionResult Save(EnrollCourses enrollCourse)
        {
            ViewBag.StudentId = db.Students.ToList();

            int studentSerId = Convert.ToInt32(Request.Form["studentId"].ToString());

            EnrollCoursesBasic enrollCoursesBasic = new EnrollCoursesBasic();

            enrollCoursesBasic = db.EnrollCoursesBasics.FirstOrDefault( a=>a.StudentId.Equals(studentSerId));

            enrollCourse.StudentId = studentSerId;
            enrollCourse.StudentSerialNum = enrollCoursesBasic.StudentSerialNum;
            enrollCourse.DepartmentName = enrollCoursesBasic.DepartmentName;
            enrollCourse.CourseId = enrollCoursesBasic.CourseId;

            int subjectID = enrollCourse.SubjectID;
            enrollCourse.SubjectID = subjectID;

            string result = Request.Form["Grade"].ToString();
            enrollCourse.Grade = result;


            //int subjectID = Convert.ToInt32(Request.Form[""].ToString());

            //Student student2 = new Student();

            //var student2 = db.Students.FirstOrDefault(a=>a.)






            //student = db.Students.

           // ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "SubjectID");

           // string deparmentID = Request.Form["departmentName"].ToString();
           // enrollCourse.DepartmentName = deparmentID;

            //string studentserialNum = Request.Form["studentId"].ToString();
            //int studentserialNumInt = Convert.ToInt32(studentserialNum);

            //Student student = new Student();

            //var students = db.Students.ToList();
            //student = db.Students.FirstOrDefault(a => a.Id == studentserialNumInt);

            //enrollCourse.StudentSerialNum = student.RegistrationSerial;

            //enrollCourse.StudentSerialNum=





            var courses = db.EnrollCourses.ToList();
            var course = courses.Where(a => (a.SubjectID == enrollCourse.SubjectID) && (a.StudentId == enrollCourse.StudentId) && (a.SubjectID == enrollCourse.SubjectID)).ToList();
            enrollCourse.date = DateTime.Now;
            if (course.Count == 0)
            {
               
                    db.EnrollCourses.Add(enrollCourse);
                    db.SaveChanges();
                   TempData["message"] = "Student Result Added Successfully!";
                //ViewBag.saveMessage = "Student Result Added Successfully!";


                return RedirectToAction("Save");
               // return View();
            }
            else
            {
                ViewBag.saveMessage = "Student result already added For thid Course";
            }

            return View();
        }



        public JsonResult GetCourseByStudentId(int studentId)
        {
            //List<Course> course = db.Courses.ToList();


            //var students = db.Students.ToList();
            //var student = students.Find(a => a.Id == studentId);
            //List<Course> courses = db.Courses.ToList();

            List<EnrollCourses> enrollCourses = enrollCourseManager.GetEnrollCourseByDepartment(studentId);
            List<Course> course = new List<Course>();
            foreach (var enrollCourse in enrollCourses)
            {
                course.Add(enrollCourseManager.GetCourseByStudent(enrollCourse.CourseId));
            }


            //return Json(course);
            return Json(course, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCourseByStudentId2(int studentId)
        {
            //List<Course> course = db.Courses.ToList();


            //var students = db.Students.ToList();
            //var student = students.Find(a => a.Id == studentId);
            //List<Course> courses = db.Courses.ToList();

            List<EnrollCoursesBasic> enrollCourses = enrollCourseManager.GetEnrollCourseBasicByDepartment(studentId);
            List<Course> course = new List<Course>();
            foreach (var enrollCourse in enrollCourses)
            {
                course.Add(enrollCourseManager.GetCourseByStudent(enrollCourse.CourseId));
            }


            //return Json(course);
            return Json(course, JsonRequestBehavior.AllowGet);
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

    }
}