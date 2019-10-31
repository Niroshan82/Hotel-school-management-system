
using RMS2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RMS2.Controllers
{
    public class ShoppingController : Controller
    {
        // GET: Shopping
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cart()
        {
            return View();
        }

        private int isExisting(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Pr.ProductID == id)
                {
                    return i;
                }

            }
            return -1;
        }

        public ActionResult Delete(int id)
        {
            int index = isExisting(id);
            List<Item> cart = (List<Item>)Session["cart"];
            cart.RemoveAt(index);
            Session["cart"] = cart;
            return View("Cart");
        }

        public ActionResult OrderNow(int id)
        {

            using (DBModel db = new DBModel())
            {
                if (Session["cart"] == null)
                {
                    List<Item> cart = new List<Item>();
                    cart.Add(new Item(db.Products.Find(id), 1));
                    Session["cart"] = cart;
                }
                else
                {
                    List<Item> cart = (List<Item>)Session["cart"];
                    int index = isExisting(id);
                    if (index == -1)
                    {
                        cart.Add(new Item(db.Products.Find(id), 1));
                    }
                    else
                    {
                        cart[index].Quantity++;
                    }

                    Session["cart"] = cart;
                    ViewBag.cartDet = cart;
                }
            }
            return View("Cart");
        }

        //public ActionResult Checkout()
        //{
        //    Item cart = Session["cart"] as Item;

        //    Order order = new Order();
        //    order.OrderNumber = "RN" + DateTime.Now.ToString("yyyy-mm-dd hh:mm ss");
        //    order.OrderName = "Order";
        //    order.Date = DateTime.Now;
        //    order.TotalMoney = cart.TotalMoney();
        //    using (DBModel db = new DBModel())
        //    {
        //        db.Orders.Add(order);
        //    }

        //    foreach (var item in cart.Items)
        //    {

        //    }
        //    return View();
        //}

        public ActionResult ckout(float total, string name)
        {
            Order order = new Order();
            List<Item> cart = Session["cart"] as List<Item>;
            
            order.OrderNumber = "RN" + DateTime.Now.ToString("yymmssfff");
            order.OrderName = name;
            order.Date = DateTime.Now;
            order.TotalMoney = total;
            order.Confirm = false;
            using (DBModel db = new DBModel())
            {
                db.Orders.Add(order);
                OrderDetails od = new OrderDetails();
                foreach (var item in cart)
                {
                    od.FoodName = item.Pr.ProductName;
                    od.Quantity = item.Quantity;
                    od.Price = item.Pr.Price;
                    db.OrderDetailss.Add(od);
                    db.SaveChanges();

                }
                db.SaveChanges();

            }

            return RedirectToAction("Index", "ConfirmPage");
        }

        public ActionResult DeleteOrder()
        {
            Session.Remove("cart");
            return RedirectToAction("CancelOrder", "Home");
        }

    }
}