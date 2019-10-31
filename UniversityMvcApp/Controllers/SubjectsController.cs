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
    public class SubjectsController : Controller
    {
        private UniversityDbContext db = new UniversityDbContext();
        DepartmentManager aDepartmentManager = new DepartmentManager();

        // GET: /TeacherCourseAssign/
        public ActionResult Create()
        {
            //ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "Code");

            //ViewBag.DepartmentId = new SelectList(db.Departments, "ID", "Code");

            ViewBag.SubCourForId = new SelectList(db.Courses, "Id", "Code");
            ViewBag.DepartmentId = db.Departments.ToList();

            ViewBag.CourseName = new SelectList(db.Courses, "Name", "Name");
            ViewBag.DepartmentName = new SelectList(db.Departments, "Name", "Name");

            ViewBag.Departments = aDepartmentManager.GetDepartments();
            return View();
        }

        // GET: Subjects
        public ActionResult Index()
        {
            var subjects = db.Subjects.Include(s => s.Course).Include(s => s.Department);
            return View(subjects.ToList());
        }

        //    // GET: Subjects/Details/5
        //    public ActionResult Details(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        Subject subject = db.Subjects.Find(id);
        //        if (subject == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(subject);
        //    }

        //    // GET: Subjects/Create
        //    public ActionResult Create()
        //    {
        //        ViewBag.SubCourForId = new SelectList(db.Courses, "Id", "Code");
        //        return View();
        //    }

        // POST: Subjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(int? DepartmentId,string DepartmentName,
        //    int? SubCourForId, string CourseName,  string SubjectId,string SubjectName, int SubjectCredit,  Subject subject)

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Subject subject)
        {
           // ViewBag.CourseID = new SelectList(db.Courses, "Id", "Id", subject.SubCourForId);

           
            // ViewBag.SubCourForId = db.Courses.ToList();

           

            ViewBag.DepartmentId = db.Departments.ToList();
            ViewBag.DepartmentName = new SelectList(db.Departments, "Name", "Name", subject.DepartmentName);
            string CourseIdV = Request.Form["Id"].ToString();
            int CourseIdVint = Convert.ToInt32(CourseIdV);
            subject.SubCourForId = CourseIdVint;
            ViewBag.CourseName = new SelectList(db.Courses, "Name", "Name", subject.CourseName);

            string subjectId = Request.Form["SubjectId"].ToString();
            subject.Code = subjectId;

            string subjectName = Request.Form["SubjectName"].ToString();
            subject.Name = subjectName;

            int subjectCredit = Convert.ToInt32(Request.Form["SubjectCredit"].ToString());
            subject.Credit = subjectCredit;

             subject.date = DateTime.Now;

            //int i;
            //for (i = 1; i < 1000; i++)
            //{

            //    int SubjectID1 = SubjectID;

            //    subject.SubjectID = i + 1;
            //}

            // subject.DepartmentId = ViewBag.DepartmentId;

            // subject.DepartmentName = ViewBag.DepartmentName;

            //subject.SubCourForId = ViewBag.CourseID;

            // subject.CourseName = ViewBag.CourseName;

            //var subjectId = SubjectId;



            //var subjectName = SubjectName;
            //subject.Name = subjectName;

            //var subjectCredit = SubjectCredit;
            //subject.Credit = subjectCredit;



            //subject.SubjectID=Autoin

            //subject.Name =ViewBag.SubjectName;
            //subject.Credit = ViewBag.SubjectCredit;
            //string SubjectId;
            //subject.Code = SubjectId;
            // string SubjectName = subject.Name;
            // int SubjectCredit = subject.Credit;

            //if (ModelState.IsValid)
            //{
            //    db.Subjects.Add(subject);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}


            if (subject!=null)
            {
                db.Subjects.Add(subject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            // ViewBag.SubCourForId = new SelectList(db.Courses, "Id", "Code", subject.SubCourForId);
            return View(subject);
        }

        //    // GET: Subjects/Edit/5
        //    public ActionResult Edit(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        Subject subject = db.Subjects.Find(id);
        //        if (subject == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        ViewBag.SubCourForId = new SelectList(db.Courses, "Id", "Code", subject.SubCourForId);
        //        return View(subject);
        //    }

        //    // POST: Subjects/Edit/5
        //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Edit([Bind(Include = "SubjectID,Code,Name,Credit,SubCourForId,date")] Subject subject)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            db.Entry(subject).State = EntityState.Modified;
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //        ViewBag.SubCourForId = new SelectList(db.Courses, "Id", "Code", subject.SubCourForId);
        //        return View(subject);
        //    }

        //    // GET: Subjects/Delete/5
        //    public ActionResult Delete(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        Subject subject = db.Subjects.Find(id);
        //        if (subject == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(subject);
        //    }

        //    // POST: Subjects/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult DeleteConfirmed(int id)
        //    {
        //        Subject subject = db.Subjects.Find(id);
        //        db.Subjects.Remove(subject);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }



        //    public ActionResult Delete(int ID)
        //{
        //    using (UniversityDbContext db = new UniversityDbContext())
        //    {
        //        var subject 
        //    }
        //}



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
