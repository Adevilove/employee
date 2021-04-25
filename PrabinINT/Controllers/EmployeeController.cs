using PrabinINT.Context;
using PrabinINT.Models;
using PrabinINT.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PrabinINT.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        EmployeeProvider pro = new EmployeeProvider();
        PBINTVEntities dbObj = new PBINTVEntities();
        public ActionResult Employee()
        {
           
            EmployeeModel model = new EmployeeModel();
           
            return View(model);

        }
        [HttpGet]
        public ActionResult Create()
        {
            var model = new EmployeeModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                pro.InsertUpdate(model);
                TempData["SuccessMessage"] = "Save successfully";
                return RedirectToAction("EmployeeList", "Employee");
            }

            return View(model);

        }
        //public ActionResult Employee(EmployeeTbl obj)
        //{
        //    if (obj != null)
        //        return View(obj);
        //    else
        //        return View();

        //}
        //[HttpPost]
        //public ActionResult AddEmployee(EmployeeTbl model)
        //{


        //         EmployeeTbl obj = new EmployeeTbl();
        //         if (ModelState.IsValid)
        //         {
        //        obj.Employee_Name = model.Employee_Name;
        //        obj.Address = model.Address;
        //        obj.Date_Of_Birth = model.Date_Of_Birth;
        //        obj.Salary = model.Salary;

        //        if (model.Id == 0)
        //        {
        //            dbObj.EmployeeTbls.Add(obj);
        //             dbObj.SaveChanges();
        //        }
        //        else
        //        {
        //            dbObj.Entry(obj).State = System.Data.EntityState.Modified;
        //            dbObj.SaveChanges();

        //        }
        //         }
        //         ModelState.Clear();
        //        return View("Employee");


        //}

        public ActionResult EmployeeList()
        {
            int page = 1;
            int pagesize = 100;
            EmployeeModel model = new EmployeeModel();
             model.EmployeeModellist = pro.GetEmployeeList();
            ViewBag.currentPage = page;
          //  ViewBag.TotalPages = Math.Ceiling((double).GetTotalItemCount() / pagesize);
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var res = dbObj.EmployeeTbls.Where(x => x.Id==id).First();
            dbObj.EmployeeTbls.Remove(res);
            dbObj.SaveChanges();
            var list = dbObj.EmployeeTbls.ToList();
            return View("Employee List", list);

        }

    }
}