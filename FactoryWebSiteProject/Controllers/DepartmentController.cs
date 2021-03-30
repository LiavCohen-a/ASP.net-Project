using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FactoryWebSiteProject.Models;

namespace FactoryWebSiteProject.Controllers
{
    public class DepartmentController : Controller
    {
        HomeBL homeBL = new HomeBL();
        DepartmentBL depBL = new DepartmentBL();
        User userData = null;
        EmployeeBL empBL = new EmployeeBL();

        
        public ActionResult DepartmentData()
        {
            userData = homeBL.GetUserData();

            if (userData != null)
            {

                var result = depBL.GetDepartments();
                ViewBag.dep = result;
                return View("DepartmentData");
            }
            return RedirectToAction("LoginPage", "Login");

        }

        public ActionResult EditPage(int depID)
        {
            userData = homeBL.GetUserData();

            if (userData != null)
            {
                var data = depBL.EditData(depID);
                return View("EditPage", data);
            }
            return RedirectToAction("LoginPage", "Login");

        }

        public ActionResult Editor(Departments Dep)
        {
            depBL.EditData(Dep);
            return RedirectToAction("DepartmentData");
        }
        public ActionResult DeleteCom(int depID)
        {
            depBL.DeleteDep(depID);
            return RedirectToAction("DepartmentData");
        }

        public ActionResult CreateDepartmentPage()
        {
            userData = homeBL.GetUserData();

            if (userData != null)
            {
                var result2 = empBL.GetEmployees();
                ViewBag.emp = result2;
                return View("CreateDepartmentPage");
            }
            return RedirectToAction("LoginPage", "Login");

        }
        public ActionResult CreateDep(Departments dep)
        {
            depBL.CreateDep(dep);
            return RedirectToAction("DepartmentData");
        }
    }
}