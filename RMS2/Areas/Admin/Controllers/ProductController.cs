using PagedList;
using RMS2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RMS2.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult Index()
        {
            //Declare list of pages
            //List<Product> productList;

            using (DBModel db = new DBModel())
            {

                return View(db.Products.ToList());
                ////Init the list
                //productList = db.Products.ToArray().OrderBy(x => x.ProductID).ToList();
                //PagedList<Product> model = new PagedList<Product>(productList, page, pageSize);
                ////Return view with list
                //return View(model);
            }
        }

        // GET: Admin/Product/AddProduct
        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }

        // POST: Admin/Product/AddProduct
        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            string fileName = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
            string extension = Path.GetExtension(product.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            product.Image = "~/Uploads/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Uploads/"), fileName);
            product.ImageFile.SaveAs(fileName);
            using (DBModel db = new DBModel())
            {
                db.Products.Add(product);
                db.SaveChanges();
                //set temp data
                TempData["SM"] = "You added new Product Successfully.";
                return RedirectToAction("Index");

            }
        }

        // GET: Admin/Product/Edit/id
        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (DBModel db = new DBModel())
            {
                Product product = db.Products.Where(x => x.ProductID == id).FirstOrDefault<Product>();
                return View(product);
            }
        }

        // POST: Admin/Product/Edit/id
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            string fileName = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
            string extension = Path.GetExtension(product.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            product.Image = "~/Uploads/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Uploads/"), fileName);
            using (DBModel db = new DBModel())
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        // GET: Admin/Product/Delete/id
        public ActionResult Delete(int id)
        {
            using (DBModel db = new DBModel())
            {
                Product product = db.Products.Where(x => x.ProductID == id).FirstOrDefault<Product>();
                db.Products.Remove(product);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
        }

        // GET: Admin/Product/ProductDetails/id
        public ActionResult ProductDetails(int id)
        {

            using (DBModel db = new DBModel())
            {
                Product product = db.Products.Find(id);
                if (product == null)
                {
                    return Content("The Product does not exist");
                }
                else
                {
                    return View(product);
                }
            }
        }
    }
}