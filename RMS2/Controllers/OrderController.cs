using RMS2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RMS2.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            using (DBModel db = new DBModel())
            {
                ViewBag.listProduct = db.Products.Where(x => x.Category == "Food").ToList();
            }
            return View();  
        }       

    }
}