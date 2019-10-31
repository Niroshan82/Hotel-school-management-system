using RMS2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RMS2.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            using (DBModel db = new DBModel())
            {

                ViewBag.productCount = db.Products.Count();
                ViewBag.customerCount = db.CustomerRegistrations.Count();
                ViewBag.employeeCount = db.Employees.Count();
                ViewBag.orderCount = db.Orders.Count();              
            }
            return View();
        }
    }
}