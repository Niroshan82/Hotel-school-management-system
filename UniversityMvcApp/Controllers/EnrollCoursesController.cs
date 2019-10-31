using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityMvcApp.BLL;
using UniversityMvcApp.DAL.Gateway;
using UniversityMvcApp.Models;

namespace UniversityMvcApp.Controllers
{
    public class EnrollCoursesController : Controller
    {
        private UniversityDbContext db = new UniversityDbContext();
        EnrollCourseManager enrollCourseManager = new EnrollCourseManager();

        StudentController studentController = new StudentController();

        // GET: EnrollCourses
        public ActionResult Index()
        {

            // var entrollCources1 = db.EnrollCoursesBasics.SqlQuery()

            //ViewBag.CourseID = db.Courses.ToList();

            //  ObjectSet<EnrollCoursesBasic> ob1 = db.EnrollCoursesBasics;

            //  enrollCourse = db.EnrollCoursesBasics.Where(s=>s.Student.Id.Equals.enrollCourse.);

            // int studentid = enrollCourse.StudentId;





            // var entrollCources = db.EnrollCoursesBasics.ToList();


            // Student student = enrollCourseManager.SearchStudentById(studentid);
            //  List<Course> course = enrollCourseManager.GetCourseByDepartment(student);

           // EnrollCoursesBasic enrollCourse = new EnrollCoursesBasic();

           // enrollCourse = db.

           var entrollCources = db.EnrollCoursesBasics.ToList();

            // var courseName = entrollCources.FirstOrDefault(s=>s.)
            // var 
            return View(entrollCources);
         
           // return View(entrollCources);
        }



        // GET: EnrollCoursesBasic
        public ActionResult Add()
        {
            ViewBag.StudentId = db.Students.ToList();
            return View();
        }
        [HttpPost]        
        public ActionResult Add(EnrollCoursesBasic enrollCourse)
        {

           // string DepartmentID = Request.Form["departmentName"];
            //enrollCourse.DepartmentName = DepartmentID;
           // ViewBag.DepartmentName = new SelectList(db.Departments, "Name", "Name", enrollCourse.DepartmentName);

            int courseID = Convert.ToInt32(Request.Form["CourseId"].ToString());

            enrollCourse.CourseId = courseID;

            string SelectedstuserialID = Request.Form["studentId"].ToString();
            ViewBag.StudentId = Convert.ToInt32(Request.Form["studentId"].ToString());

            int IntSelectedstuserialID = Convert.ToInt32(Request.Form["studentId"].ToString());

            enrollCourse.StudentId = IntSelectedstuserialID;

            Student student = new Student();

            student = db.Students.FirstOrDefault(a => a.Id==IntSelectedstuserialID);

            Department department = new Department();


            department = db.Departments.FirstOrDefault(u => u.ID.Equals(student.DepartmentId));

            ViewBag.DepartmentName = department.Name;

            enrollCourse.DepartmentName = department.Name;


            //string StudentSerialNum = db.Students.FirstOrDefault(u => u.Id.Equals(IntSelectedstuserialID)).ToString();
            // student = studentController.FindByID(int IntSelectedstuserialID);

            enrollCourse.StudentSerialNum = student.RegistrationSerial;

            //string StudentSerialNum = db.Students.Where(b => b.RegistrationSerial == SelectedstuserialID).Single();
            // ViewBag.CourseId = new SelectList(db.Students,)

            ViewBag.StudentId = db.Students.ToList();

            EnrollCoursesBasic enrollCoursesBasic = new EnrollCoursesBasic();

            enrollCoursesBasic = db.EnrollCoursesBasics.FirstOrDefault(a => (a.CourseId == enrollCourse.CourseId) && (a.StudentId == enrollCourse.StudentId));

            // ViewBag.DepartmentName = ViewBag.StudentId



            // var course = courses.Where(a => (a.CourseId == enrollCourse.CourseId) && (a.StudentId==enrollCourse.StudentId) ).ToList();

            //if (course.Count == 0)
            //{
            if (enrollCoursesBasic==null)
            {

                db.EnrollCoursesBasics.Add(enrollCourse);
                    db.SaveChanges();
                    ViewBag.saveMessage = "Student Basic Course details Enrolled Successfull!";

                //return RedirectToAction("Add");

                

                return View();
            }
            else
            {
                ViewBag.EnrollExist = "Student has already Enrolled For thid Course";
            }

            return View();
        }

        public JsonResult GetCourseByStudentId(int studentId)
        {
            //List<Course> course = db.Courses.ToList();


            //var students = db.Students.ToList();
            //var student = students.Find(a => a.Id == studentId);
            //List<Course> courses = db.Courses.ToList();
            Student student = enrollCourseManager.SearchStudentById(studentId);
            List<Course> course = enrollCourseManager.GetCourseByDepartment(student);
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