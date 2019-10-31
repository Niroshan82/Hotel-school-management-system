using RMS2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RMS2.Areas.Admin.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Admin/Customer
        public ActionResult Index()
        {
            try
            {
                using (DBModel db = new DBModel())
                {
                    return View(db.CustomerRegistrations.ToList());
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }        
        }

        public ActionResult Details(int id)
        {
            using (DBModel db = new DBModel())
            {
                CustomerRegistration customer = db.CustomerRegistrations.Where(x => x.RegistrationID == id).FirstOrDefault();

                return PartialView("DetailsPV", customer);
            }
        }
    }
}