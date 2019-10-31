using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RMS2.Controllers
{
    public class ConfirmPageController : Controller
    {
        // GET: ConfirmPage
        public ActionResult Index()
        {

            TempData["message"] = "payment successfully added";

            return RedirectToAction("Index");
        }

      
    }
}