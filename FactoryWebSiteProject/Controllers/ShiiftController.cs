using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FactoryWebSiteProject.Models;

namespace FactoryWebSiteProject.Controllers
{
    public class ShiiftController : Controller
    {
        HomeBL homeBL = new HomeBL();
        ShiftBL shiftBL = new ShiftBL();
        EmployeeBL EmployeeBL = new EmployeeBL();
        
        // GET: Shiift
        public ActionResult AddShift()
        {
            var userData = homeBL.GetUserData();

            if (userData != null)
            {
                return View("AddShift");
            }

            return RedirectToAction("LoginPage", "Login");
           
        }
        public ActionResult AddShiftToEmp(Shifts shi)
        {
            shiftBL.AddShifts(shi);           
            return RedirectToAction("GetShiftDataPage");
        }
        public ActionResult DeleteFromShift(string name)
        {

            var userData = homeBL.GetUserData();


            if (userData != null)
            {
                shiftBL.DeleteByName(name);
                return RedirectToAction("GetShiftDataPage");
            }

            return RedirectToAction("LoginPage", "Login");


        }
        public ActionResult GetShiftDataPage()
        {
            var userData = homeBL.GetUserData();


            if (userData != null)
            {
                var result = shiftBL.GetShiftPer();
                var result2 = shiftBL.GetEmpNameToShift(result);

                ViewBag.shi = result;
                ViewBag.Name = result2;
               ViewBag.Emp = EmployeeBL.GetEmployees();
                return View("GetShiftDataPage");
            }

            return RedirectToAction("LoginPage", "Login");


            
        }
       
    }
}