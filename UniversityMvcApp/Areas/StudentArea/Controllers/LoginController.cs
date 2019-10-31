using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityMvcApp.Models;

namespace UniversityMvcApp.Areas.StudentArea.Controllers
{
    public class LoginController : Controller
    {
        // GET: StudentArea/Login
        public ActionResult Index()
        {
            return View();
        }

        // GET: StudentArea/Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StudentArea/Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentArea/Login/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        string username = Request.Form["username"].ToString();
        //        string password = Request.Form["password"].ToString();


        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        [HttpPost]
        public ActionResult Create(int UserType, string userName, string password)
         {

            // string userType = UserType;
            // string userType = Request.Form["UserType"].ToString();
            // int iUserType = Convert.ToInt32(userType);

            int iUserType = UserType;

            // if (userType == null)
            if (iUserType == 0)
            {
                string ErrormMssage = "Please select the user type!!!";

                return Json(new { Success = false, ErrormMssage = ErrormMssage }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                
                if (iUserType == 1)
                {
                    using (UniversityDbContext db = new UniversityDbContext())
                    {
                        var data = db.UserAdmins.Where(s => s.UserName == userName && s.Password == password).FirstOrDefault();

                        // string message = "Login successfully!!!";
                        string ErrormMssage = "Wrong User Name or Password!!!";

                        if (data != null)
                        {
                            Session["AdminID"] = data.UserID;
                            Session["adminName"] = data.UserName;
                                
                            return RedirectToAction("Index", "Home", new { area=""});



                            // return Json(new { Success = true, message = message }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { Success = false, ErrormMssage = ErrormMssage }, JsonRequestBehavior.AllowGet);
                        }
                    }

                } 
                else if (iUserType == 2)
                {
                    using (UniversityDbContext db2 = new UniversityDbContext())
                    {
                        var data2 = db2.User.Where(x => x.UserName == userName && x.Password == password).FirstOrDefault();

                        // string message = "Login successfully!!!";
                        string ErrormMssage = "Wrong User Name or Password!!!";

                        if (data2 != null)
                        {
                            Session["studentID"] = data2.UserID;
                            Session["studentName"] = data2.UserName;

                            return RedirectToAction("Index", "Home2");

                            // return Json(new { Success = true, message = message }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { Success = false, ErrormMssage = ErrormMssage }, JsonRequestBehavior.AllowGet);
                        }
                    }

                }
                else
                {
                    using (UniversityDbContext db = new UniversityDbContext())
                    {
                        var data = db.UserTeachers.Where(s => s.UserName == userName && s.Password == password).FirstOrDefault();

                        // string message = "Login successfully!!!";
                        string ErrormMssage = "Wrong User Name or Password!!!";

                        if (data != null)
                        {
                            Session["teacherID"] = data.UserID;
                            Session["teacherName"] = data.UserName;

                            return RedirectToAction("Index", "Home3",new {area="TeacherArea" });

                            // return Json(new { Success = true, message = message }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { Success = false, ErrormMssage = ErrormMssage }, JsonRequestBehavior.AllowGet);
                        }
                    }
                }
            }
           

           
        }


        public ActionResult Logout()
        {
           // int userID = (int)Session[""];
          //  string userName = Session["adminName"].ToString();
           // string userName2 = Session["studentName"].ToString();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

        // GET: StudentArea/Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentArea/Login/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentArea/Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentArea/Login/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
