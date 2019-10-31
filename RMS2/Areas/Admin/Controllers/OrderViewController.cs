using RMS2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RMS2.Areas.Admin.Controllers
{
    public class OrderViewController : Controller
    {
        // GET: Admin/OrderView
        public ActionResult Index()
        {
            using (DBModel db = new DBModel())
            {
                return View(db.Orders.ToList());
            }
        }

        public ActionResult ConfirmOrder(int id)
        {
            using (DBModel db = new DBModel())
            {
                Order order = db.Orders.Where(o => o.OrderID == id).FirstOrDefault();
                return PartialView("ConfirmOrderPV", order);
            }
        }


        [HttpPost]
        public ActionResult ConfirmOrder(Order order)
        {
            using (DBModel db = new DBModel())
            {               
                db.Entry(order).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

        }

        public ActionResult ViewOrders(int id)
        {
            using (DBModel db = new DBModel())
            {
                List<OrderDetails> order = db.OrderDetailss.Where(x => x.OrderID == id).ToList();
                return PartialView("ViewOrdersPV", order);
            }
        }

        public ActionResult Print(int id)
        {
            using (DBModel db = new DBModel())
            {
                string invoiceNo = "TH" + DateTime.Now.ToString("yyffff");
                ViewBag.invoiceNo = invoiceNo;

                Order od = db.Orders.Where(x => x.OrderID == id).FirstOrDefault();
                ViewBag.orderNo = od.OrderNumber;
                ViewBag.total = od.TotalMoney;
                ViewBag.name = od.OrderName;

                List<OrderDetails> order = db.OrderDetailss.Where(x => x.OrderID == id).ToList();
                return PartialView("Print", order);
            }
        }
    }
}