    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FactoryWebSiteProject.Models;

namespace FactoryWebSiteProject.Controllers
{
    public class EmployeeController : Controller
    {
        HomeBL homeBL = new HomeBL();
        EmployeeBL empBL = new EmployeeBL();
        DepartmentBL depBL = new DepartmentBL();
        ShiftBL shiftBL = new ShiftBL();

        // GET: Employee
        public ActionResult EmployeeDataPage()
        {
            var userData = homeBL.GetUserData();


            if (userData != null)
            {
                var result2 = empBL.ShiftToEmp().ToList();
                var result = empBL.GetEmployees();
                ViewBag.Emp = result;
                ViewBag.Shifts = result2;

                return View("EmployeeDataPage");
            }

                return RedirectToAction("LoginPage", "Login");
  

        }
        public ActionResult EmployeenewData(string name)
        {
            var userData = homeBL.GetUserData();


            if (userData != null)
            {
                var result2 = empBL.ShiftToEmp().ToList();
                var result = empBL.getselectedEmployee(name);
                ViewBag.Emp = result;
                ViewBag.Shifts = result2;

                return View("EmployeeDataPage");
            }

            return RedirectToAction("LoginPage", "Login");


        }
        public ActionResult AddEmployeePage()
        {
            var userData = homeBL.GetUserData();
            

            if (userData != null)
            {
                var deps = depBL.GetDepartments();
                ViewBag.dep = deps;
                return View("AddEmployeePage");
            }

            return RedirectToAction("LoginPage", "Login");
        }
        public ActionResult GetNewEmp(Employee emp)
        {
            var userData = homeBL.GetUserData();


            if (userData != null)
            {

                empBL.AddEmployees(emp);
                return RedirectToAction("EmployeeDataPage");
            }

            return RedirectToAction("LoginPage", "Login");
        }
        public ActionResult EditEmployeePage(int empID)
        {
            var userData = homeBL.GetUserData();

            if (userData != null)
            {
                var deps = depBL.GetDepartments();
                ViewBag.dep = deps;
                var result = empBL.GetEditor(empID);
                return View("EditEmployeePage", result);
            }

            return RedirectToAction("LoginPage", "Login");
        }
        public ActionResult NewEmployeeData(Employee emp)
        {
            empBL.Getdata(emp);
            return RedirectToAction("EmployeeDataPage");
        }
        public ActionResult DeleteCom(int empID)
        {
            empBL.DeleteEmp(empID);
            return RedirectToAction("EmployeeDataPage");
        }

        public ActionResult AddShiftToEmp(int EmpID)
        {
            var userData = homeBL.GetUserData();
            if (userData != null)
            {
                ViewBag.EmpID = EmpID;
                var result = shiftBL.GetShiftPer();
                ViewBag.Shifts = result;
                return View("AddShiftToEmp");
            }
            return RedirectToAction("LoginPage", "Login");
        }
        public ActionResult AddShift(int EmployeeID, int ShiftID)
        {
            var userData = homeBL.GetUserData();
            if (userData != null)
            {
                empBL.AddShiftToEmp(ShiftID, EmployeeID);
                return RedirectToAction("EmployeeDataPage");
            }
            return RedirectToAction("LoginPage", "Login");
        }
    }
}