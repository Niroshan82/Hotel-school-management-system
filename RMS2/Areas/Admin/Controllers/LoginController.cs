using RMS2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RMS2.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autherize(User user)
        {
           
            using (DBModel db = new DBModel())
            {
                //EncryptionDetail encryptionDetail = new EncryptionDetail();
                var userDetails = db.Users.Where(x => x.UserName == user.UserName && x.Password == user.Password).FirstOrDefault();
                if(userDetails == null)
                {
                    //EncryptionDetail encryptionDetail = new EncryptionDetail();

                    user.LoginErrorMessage = "Wrong Username or Password";
                    return View("Index",user);
                }
                else
                {
                    Session["userID"] = user.UserID;
                    Session["userName"] = user.UserName;
                    return RedirectToAction("Index", "Dashboard");
                }
            }
            
        }

        public ActionResult Logout()
        {
            int userID = (int)Session["userID"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}