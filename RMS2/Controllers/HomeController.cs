using RMS2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RMS2.Util;
using RMS2.Areas.Admin.Controllers;
using System.Data.Entity.Validation;

namespace RMS2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Services()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Menu()
        {
            using(DBModel db = new DBModel())
            {
                ViewBag.listProduct = db.Products.Where(x => x.Category == "Food").ToList();
            }
            return View();

        }

        public ActionResult MenuPV(int id)
        {
            using (DBModel db = new DBModel())
            {
                Product product = db.Products.Where(x => x.ProductID == id).FirstOrDefault();
                return PartialView("MenuPV", product);
            }
            
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(CustomerRegistration customer)
        {
            //EncryptionDetail encryptionDetail = new EncryptionDetail();
            try
            {
                string message = "Register successfully!!!";
                bool status = true;
                //customer.Password = encryptionDetail.GetEncryptedString(customer.Password);
                using (DBModel db = new DBModel())
                {
                    var keyNew = Helper.GeneratePassword(10);
                    var password = Helper.EncodePassword(customer.Password, keyNew);
                    customer.Password = password;
                    customer.ConfirmPassword = keyNew;
                    customer.CreateDate = DateTime.Now;
                    customer.ModifyDate = DateTime.Now;
                    customer.VCode = keyNew;

                    db.CustomerRegistrations.Add(customer);
                    db.SaveChanges();
                    return Json(new { status = status, message = message, id = db.CustomerRegistrations.Max(x => x.RegistrationID) }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPost]
        public ActionResult ValidateUser(string userName, string password)
        {
            using (DBModel db = new DBModel())
            {
                var getUser = (from s in db.CustomerRegistrations where s.UserName == userName select s).FirstOrDefault();


                CustomerRegistration customer = new CustomerRegistration();
                string message = "Login successfully!!!";
                string ErrormMssage = "Wrong User Name or Password!!!";

               

               
                var hashCode = getUser.VCode;
                //Password Hasing Process Call Helper Class Method    
                var encodingPasswordString = Helper.EncodePassword(password, hashCode);
                //Check Login Detail User Name Or Password 


                var data = db.CustomerRegistrations.Where(o => o.UserName == userName && o.Password == encodingPasswordString).FirstOrDefault();

                if (data!=null)
                {
                    Session["customerID"] = data.RegistrationID;
                    Session["customerName"] = data.FirstName;
                    return Json(new { Success = true, message= message }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Success = false, ErrormMssage= ErrormMssage }, JsonRequestBehavior.AllowGet);
                }
            }
            
        }

        public ActionResult Logout()
        {
            int userID = (int)Session["customerID"];
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult CancelOrder()
        {
            return View();
        }
    }
}