using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using LatihanStoreProc.Models;

namespace LatihanStoreProc.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        Database_Access_Layer.Database dbLayer = new Database_Access_Layer.Database();
        public ActionResult ListEmployee()
        {
            DataSet dataSet = dbLayer.ShowAllData();
            ViewBag.emp = dataSet.Tables[0];
            return View();
        }
        public ActionResult AddEmployee()
        {
        
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(FormCollection form)
        {
            Employee employee = new Employee();
            employee.Name = form["Name"];
            employee.Address = form["Adrress"];
            employee.City = form["City"];
            employee.Pin_Code = form["Pin_Code"];
            employee.Designation = form["Designation"];
            dbLayer.AddRecord(employee);
            TempData["msg"] = "Success Create Employee";
            return RedirectToAction("ListEmployee");
        }

        public ActionResult UpdateEmployee(int id)
        {
            DataSet dataSet = dbLayer.ShowData(id);
            ViewBag.empData = dataSet.Tables[0];
            return View();
        }
        [HttpPost]
        public ActionResult UpdateEmployee(int id, FormCollection form)
        {
            Employee employee = new Employee();
            employee.Id = id;
            employee.Name = form["Name"];
            employee.Address = form["Adrress"];
            employee.City = form["City"];
            employee.Pin_Code = form["Pin_Code"];
            employee.Designation = form["Designation"];
            dbLayer.Update(employee);
            TempData["msg"] = "Update Success";
            return RedirectToAction("ListEmployee");
        }

        public ActionResult DeleteEmployee(int id)
        {
            dbLayer.delete(id);
            TempData["msg"] = "Success Deleted";
            return RedirectToAction("ListEmployee");
        }

    }
}
