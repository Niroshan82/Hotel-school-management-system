using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversityMvcApp.BLL;
using UniversityMvcApp.Models;

namespace UniversityMvcApp.Controllers
{
    public class StudentController : Controller
    {
        StudentManager studentManager = new StudentManager();
        private UniversityDbContext db = new UniversityDbContext();
        DepartmentManager aDepartmentManager = new DepartmentManager();

        public ActionResult Index()
        {
            var students = db.Students.Include(s => s.Department).Include(s => s.Course);
            return View(students.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           Student student = db.Students.Find(id);

            var courses = db.Courses.ToList();
            Course Course = courses.Find(b => b.Id==student.CourID);
            student.Course.Name = Course.Name;

            var departments = db.Departments.ToList();
           Department Department = departments.Find(a=>a.ID==student.DepartmentId);
           student.Department.Name = Department.Name;

            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }
         public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "ID", "Code");
            ViewBag.CourID = new SelectList(db.Courses, "Id", "Code");
            ViewBag.DepartmentId = db.Departments.ToList();

            ViewBag.Departments = aDepartmentManager.GetDepartments();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Student student)
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "ID", "Code");
            ViewBag.CourID = new SelectList(db.Courses, "Id", "Code");
            ViewBag.DepartmentId = db.Departments.ToList();

            student.RegistrationSerial = studentManager.GetRegistration(student);
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                TempData["Message"] = "added";
                //return RedirectToAction("Details", new { id=student.Id });
                return RedirectToAction("Index");
            }
            //ViewBag.Message = "Saved successfully";
            return View(student);
        }

      
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //public Student FindByID(int IntSelectedstuserialID)
        //{
        //    //using (var context = new UniversityDbContext())
        //    //{
        //    //StudentSerialNum = db.Students.FirstOrDefault(u => u.Id.Equals(IntSelectedstuserialID)).ToString();

        //    //Student student = new Student();

        //    // student=db.Students(a=>a.)

        //    return db.Students.FirstOrDefault(a => a.Id == IntSelectedstuserialID).ToList();
        //    //}
        //}
    }
}
