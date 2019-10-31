using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversityMvcApp.BLL;
using UniversityMvcApp.Models;

namespace UniversityMvcApp.Controllers
{
    public class AllocateClassRoomsController : Controller
    {
        public UniversityDbContext db = new UniversityDbContext();


        AllocateClassRoomManager allocateClassroomManager = new AllocateClassRoomManager();

        DepartmentManager aDepartmentManager = new DepartmentManager();
        // GET: AllocateClassRooms
        public ActionResult Index()
        {
            var allocateClassRooms = db.AllocateClassRooms.Include(a => a.Course).Include(a => a.Department).Include(a => a.Subject).Include(a => a.Room);
            return View(allocateClassRooms.ToList());
        }

        // GET: AllocateClassRooms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllocateClassRoom allocateClassRoom = db.AllocateClassRooms.Find(id);
            if (allocateClassRoom == null)
            {
                return HttpNotFound();
            }
            return View(allocateClassRoom);
        }

        // GET: AllocateClassRooms/Create
        public ActionResult Create()
        {
            ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "Code");
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Code");
            //ViewBag.DepartmentId = new SelectList(db.Departments, "ID", "Code");
            ViewBag.DepartmentId = db.Departments.ToList();

            ViewBag.RoomId = new SelectList(db.Rooms, "Id", "RoomNo");

            ViewBag.Departments = aDepartmentManager.GetDepartments();

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(AllocateClassRoom allocateClassRoom)
        {
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Code", allocateClassRoom.CourseId);
            ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "Code", allocateClassRoom.SubjectID);
            ViewBag.DepartmentId = db.Departments.ToList();
            ViewBag.RoomId = new SelectList(db.Rooms, "Id", "RoomNo", allocateClassRoom.RoomId);
            allocateClassRoom.StartTime = DateTime.ParseExact(allocateClassRoom.From, "h:mm tt", CultureInfo.InvariantCulture).TimeOfDay;
            allocateClassRoom.FinishTime = DateTime.ParseExact(allocateClassRoom.To, "h:mm tt", CultureInfo.InvariantCulture).TimeOfDay;
            if (!AllocateClassRoomManager.HasClass(allocateClassRoom))
            {
                if (allocateClassroomManager.IsTimeAlocated(allocateClassRoom))
                {
                    ViewBag.Errormessage = "Room Is Allocated For This Time Interval";
                    return View();
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        db.AllocateClassRooms.Add(allocateClassRoom);
                        db.SaveChanges();

                        TempData["Addx"] = "Allocated Succesfully!!!";

                        return RedirectToAction("Index");


                        //ViewBag.saveMessage = "Allocated Succesfully!!!";
                    }


                    return View(allocateClassRoom);

                }
            }
            else
            {
                ViewBag.Errormessage = "This Course has already been allocated at this time";
                return View(allocateClassRoom);
            }
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AllocateClassRoom allocateClassRoom)
        {


            string subID = Request.Form["SubjectID"].ToString();



            var subject = db.Subjects.Where(s => s.Code == subID).FirstOrDefault();

            int departmentID = Convert.ToInt32(subject.DepartmentId);
            int CourseID = Convert.ToInt32(subject.SubCourForId);
            int SubjectID = subject.SubjectID;
            

            string roomNo = Request.Form["RoomId"].ToString();

            var room = db.Rooms.Where(s => s.RoomNo == roomNo).FirstOrDefault();

            int roomID = room.Id;


            //int roomID = Convert.ToInt32(Request.Form["RoomId"].ToString());



            //ViewBag.CourseId = new SelectList(db.Courses, "Id", "Code", allocateClassRoom.CourseId);
            //ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "Code", allocateClassRoom.SubjectID);
            //ViewBag.DepartmentId = db.Departments.ToList();


            //ViewBag.RoomId = new SelectList(db.Rooms, "Id", "RoomNo", allocateClassRoom.RoomId);


            allocateClassRoom.DepartmentId = departmentID;
            allocateClassRoom.CourseId = CourseID;
            allocateClassRoom.SubjectID = SubjectID;
            allocateClassRoom.RoomId = roomID;


            allocateClassRoom.StartTime = DateTime.ParseExact(allocateClassRoom.From, "h:mm tt", CultureInfo.InvariantCulture).TimeOfDay;
            allocateClassRoom.FinishTime = DateTime.ParseExact(allocateClassRoom.To, "h:mm tt", CultureInfo.InvariantCulture).TimeOfDay;

            if (!AllocateClassRoomManager.HasClass(allocateClassRoom))
            {
                if (allocateClassroomManager.IsTimeAlocated(allocateClassRoom))
                {
                    ViewBag.Errormessage = "Room Is Allocated For This Time Interval";
                    return View();
                }
                else
                {
                  //  if (ModelState.IsValid)
                  //  {
                       // db.AllocateClassRooms.Add(allocateClassRoom);
                       // db.SaveChanges();

                      //  TempData["Addx"] = "Allocated Succesfully!!!";

                       

                        db.Entry(allocateClassRoom).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");


                    //ViewBag.saveMessage = "Allocated Succesfully!!!";
                    // }


                    //  return View(allocateClassRoom);

                }
            }
            else
            {
                ViewBag.Errormessage = "This Course has already been allocated at this time";
                return View(allocateClassRoom);
            }




          //  return View(allocateClassRoom);

        }





            public JsonResult GetCourseByDepartmentId(int departmentId)
        {
            ////List<Course> course = db.Courses.ToList();
            //Student student = enrollCourseManager.SearchStudentById(studentId);
            //List<Course> course = enrollCourseManager.GetCourseByDepartment(student);
            ////return Json(course);
            //return Json(course, JsonRequestBehavior.AllowGet);


            //Department department =

            List<Course> courses = allocateClassroomManager.GetAllCourses();
            var course = courses.Where(a => a.DepartmentId == departmentId).ToList();
            //return Json(course);
            return Json(course, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSubjectByCourseId(int CourseId)
        {
            //List<Course> course = db.Courses.ToList();

            List<Subject> subjects = allocateClassroomManager.GetSubjectByDepartmentId();
            var Subjects = subjects.Where(a => a.SubCourForId == CourseId).ToList();
           // return Json(Subjects);
            return Json(Subjects, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetRoomsByDepartmentId(int departmentId)
        {
            List<Room> rooms = db.Rooms.ToList();
            var room = rooms.Where(a => a.DepartmentId == departmentId).ToList();
            return Json(room);
           
        }

        public ActionResult Delete(int ID)
        {
            using (UniversityDbContext db =new UniversityDbContext())
            {
                var allocateClassRoom = db.AllocateClassRooms.Where(s => s.Id == ID).FirstOrDefault();

                db.AllocateClassRooms.Remove(allocateClassRoom);
                db.SaveChanges();
                TempData["message"] = "Delete Successfully!!!";

                return RedirectToAction("Index");


            }
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {

            using (UniversityDbContext db=new UniversityDbContext())
            {

                //IEnumerable<Room> rooms;

                ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "Code");
                ViewBag.CourseId = new SelectList(db.Courses, "Id", "Code");               
                ViewBag.DepartmentId = db.Departments.ToList();

                ViewBag.RoomId = db.Rooms.ToList();

              // var rooms = db.Rooms.ToList();

                //ViewBag.RoomId = new SelectList(db.Rooms, "Id", "RoomNo");

                ViewBag.Departments = aDepartmentManager.GetDepartments();


                AllocateClassRoom allocateClassRoom = new AllocateClassRoom();

                var allocateClassRooms = db.AllocateClassRooms.Include(a => a.Course).Include(a => a.Department).Include(a => a.Subject).Include(a => a.Room).ToList();


                var getAllocationDetails = db.AllocateClassRooms.Where(s => s.Id == ID).FirstOrDefault();

               // allocateClassRoom.Id = getAllocationDetails.Id;

                Department department = new Department();

                var departmnt = db.Departments.Where(s => s.ID == getAllocationDetails.DepartmentId).FirstOrDefault();
                ViewData["DepartmentData"] = departmnt.Code;

                var course = db.Courses.Where(s => s.Id == getAllocationDetails.CourseId).FirstOrDefault();
                ViewData["CourseData"] = course.Code;

                var subject = db.Subjects.Where(s => s.SubjectID == getAllocationDetails.SubjectID).FirstOrDefault();
                ViewData["subjectData"] = subject.Code;

                var room = db.Rooms.Where(x => x.Id == getAllocationDetails.RoomId).FirstOrDefault();
                ViewData["roomData"] = room.RoomNo;

                ViewData["DayValue"] = getAllocationDetails.Day;






                allocateClassRoom.DepartmentId = getAllocationDetails.DepartmentId;
                allocateClassRoom.CourseId = getAllocationDetails.CourseId;
                allocateClassRoom.SubjectID = getAllocationDetails.SubjectID;
                allocateClassRoom.RoomId = getAllocationDetails.RoomId;
                allocateClassRoom.date = getAllocationDetails.date;
               allocateClassRoom.Day = getAllocationDetails.Day;
                allocateClassRoom.From = getAllocationDetails.From;
                allocateClassRoom.To = getAllocationDetails.To;
                allocateClassRoom.StartTime = getAllocationDetails.StartTime;
                allocateClassRoom.FinishTime = getAllocationDetails.FinishTime;

                return View(allocateClassRoom);




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
