using RMS2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RMS2.Areas.Admin.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Admin/Employee
        public ActionResult Index()
        {
            try
            {
                using (DBModel db = new DBModel())
                {
                    return View(db.Employees.ToList());
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        // POST: Admin/Save
        [HttpPost]
        public ActionResult Save(Employee emp)
        {
            try
            {
                string message = "Feedback send successfully!!!";
                bool status = true;
                using (DBModel db = new DBModel())
                {
                    db.Employees.Add(emp);
                    db.SaveChanges();
                    return Json(new { status = status, message = message, id = db.Employees.Max(x => x.EmployeeID) }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ActionResult Delete(int ID)
        {
            try
            {
             
                using (DBModel db = new DBModel())
                {
                    var employee = db.Employees.Where(x => x.EmployeeID == ID).FirstOrDefault();
                    db.Employees.Remove(employee);
                    db.SaveChanges();
                    string message = "Delete successfully!!!";
                    bool status = true;
                    return Json(new { status = status, message = message }, JsonRequestBehavior.AllowGet);

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ActionResult GetEmployee(int ID)
        {
            using (DBModel db = new DBModel())
            {
                Employee employee = new Employee();
                var getEmp = db.Employees.Where(x => x.EmployeeID == ID).FirstOrDefault();
                employee.EmployeeID = getEmp.EmployeeID;
                employee.EmpCode = getEmp.EmpCode;
                employee.Status = getEmp.Status;
                employee.FirstName = getEmp.FirstName;
                employee.LastName = getEmp.LastName;
                employee.Gender = getEmp.Gender;
                employee.NicNo = getEmp.NicNo;
                employee.ContactNo = getEmp.ContactNo;
                employee.Email = getEmp.Email;
                employee.Address = getEmp.Address;
                employee.Position = getEmp.Position;
                return Json(new { success = true, data = employee }, JsonRequestBehavior.AllowGet);


            }
            //return View();
        }

        public ActionResult UpdateEmployee(Employee emp)
        {
            using (DBModel db = new DBModel())
            {
                db.Entry(emp).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                string message = "Recored has been updated successfully";
                bool status = true;
                return Json(new { status = status, message = message }, JsonRequestBehavior.AllowGet);
            }
           
        }

    }
}