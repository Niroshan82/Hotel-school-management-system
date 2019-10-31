using RMS2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RMS2.Controllers
{
    public class CustomerAdminController : Controller
    {
        // GET: CustomerAdmin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewOrders()
        {
            string name = (string)Session["customerName"];
            List<Order> orderList = new List<Order>();
            using (DBModel db = new DBModel())
            {
                orderList = db.Orders.Where(x => x.OrderName == name).ToList();

                return View(orderList);
            }
            
        }

        public ActionResult Print(int id)
        {
            using (DBModel db = new DBModel())
            {
                Order od = db.Orders.Where(x => x.OrderID == id).FirstOrDefault();
                ViewBag.total = od.TotalMoney;

                List<OrderDetails> order = db.OrderDetailss.Where(x => x.OrderID == id).ToList();
                return PartialView("ViewCstomerOrderPV", order);
            }
        }

        public ActionResult ProfileCustomer()
        {
            int id = (int)Session["customerID"];
            using (DBModel db = new DBModel())
            {
                List<CustomerRegistration> customer = db.CustomerRegistrations.Where(x => x.RegistrationID == id).ToList();
                return View(customer);
            }
               
        }

        public ActionResult Edit(int id)
        {
            using (DBModel db = new DBModel())
            {
                CustomerRegistration customer = db.CustomerRegistrations.Where(o => o.RegistrationID == id).FirstOrDefault();
                return PartialView("EditPV", customer);
            }
        }

        [HttpPost]
        public ActionResult Edit(CustomerRegistration customer)
        {
            using (DBModel db = new DBModel())
            {
                db.Entry(customer).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("ProfileCustomer");
            }
        }
    }
}