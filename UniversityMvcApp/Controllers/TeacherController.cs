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
    public class TeacherController : Controller
    {
        TeacherManager aTeacherManager = new TeacherManager();
        private UniversityDbContext db = new UniversityDbContext();

        // GET: /Teacher/
        public ActionResult Index()
        {
            var teachers = db.Teachers.Include(t => t.Designation).Include(s => s.Department);
            return View(teachers.ToList());
        }

        // GET: /Teacher/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // GET: /Teacher/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "ID", "Code");
            ViewBag.DesignationId = new SelectList(db.Designations, "ID", "DesignationName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Teacher teacher)
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "ID", "Code");
            ViewBag.DesignationId = new SelectList(db.Designations, "ID", "DesignationName");
            if (!aTeacherManager.DoesEmailExist(teacher.Email))
            {
                if (ModelState.IsValid)
                {
                    db.Teachers.Add(teacher);
                    db.SaveChanges();
                    TempData["Message"] = "added";
                    return RedirectToAction("Create");
                    // ViewBag.saveMessage = "Teacher Information Saved!";

                }

                return View();
            }

            else
            {
                @ViewBag.ExistMessage = "Email already exists!";
                return View();
            }

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
