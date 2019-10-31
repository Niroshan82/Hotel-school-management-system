using RMS2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RMS2.Areas.Admin.Controllers
{
    public class FeedBackController : Controller
    {
        // GET: Admin/FeedBack
        public ActionResult Index()
        {
            using (DBModel db = new DBModel())
            {
                List<Feedback> feedbacklist = db.Feedbacks.ToList();
                ViewBag.listFeedback = feedbacklist;
                return View();
            }
           
        }
    }
}