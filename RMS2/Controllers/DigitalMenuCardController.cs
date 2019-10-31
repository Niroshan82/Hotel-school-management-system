using RMS2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RMS2.Controllers
{
    public class DigitalMenuCardController : Controller
    {
        // GET: DigitalMenuCard
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Meals()
        {
            using (DBModel db = new DBModel())
            {
                ViewBag.listMeals = db.Products.Where(x => x.Category == "Food").ToList();
            }
            return View();
        }

        public ActionResult Drinks()
        {
            using (DBModel db = new DBModel())
            {
                ViewBag.listDrinks = db.Products.Where(x => x.Category == "Drink").ToList();
            }
            return View();
        }

        public ActionResult Desearts()
        {
            using (DBModel db = new DBModel())
            {
                ViewBag.listDesearts = db.Products.Where(x => x.Category == "Deserts").ToList();
            }
            return View();
        }

        public ActionResult ShortEats()
        {
            using (DBModel db = new DBModel())
            {
                ViewBag.listShortEats = db.Products.Where(x => x.Category == "ShortEats").ToList();
            }
            return View();
        }

        public ActionResult SpecialOfTheDay()
        {
            return View();
        }

        public ActionResult FeedBack()
        {
            return View();
        }

        public ActionResult MealsPV(int id)
        {
            using (DBModel db = new DBModel())
            {
                Product product = db.Products.Where(x => x.ProductID == id).FirstOrDefault();
                return PartialView("MealsPV", product);
            }
        }

        [HttpPost]
        public ActionResult SaveFeedBack(Feedback feedback)
        {
            try
            {
                string message = "Saved successfully!!!";
                bool status = true;
                feedback.EnteredDate = System.DateTime.Now;
                using (DBModel db = new DBModel())
                {
                    db.Feedbacks.Add(feedback);
                    db.SaveChanges();
                    return Json(new { status = status, message = message, id = db.Feedbacks.Max(x => x.FeedbackID) }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ActionResult Quantity()
        {
            using (DBModel db = new DBModel())
            {
                return PartialView("QuantityPV");
            }
        }

        
        public ActionResult Cart(int id, int qty)
        {
            using (DBModel db = new DBModel())
            {
                Product product = db.Products.Where(x => x.ProductID == id).FirstOrDefault();
                ViewBag.quantity = qty;
                return View("Cart", product);
            }
                
        }
    }
}