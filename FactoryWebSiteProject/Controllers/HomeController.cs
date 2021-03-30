using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FactoryWebSiteProject.Models;

namespace FactoryWebSiteProject.Controllers
{
    public class HomeController : Controller
    {
        HomeBL homeBL = new HomeBL();
        //User userData = null;


        public ActionResult Index()
        {
            return RedirectToAction("LoginPage","Login");
        }

    
        public ActionResult HomePage(User user)
        {
  

            var userData = homeBL.GetUserData();

            if (userData != null )
            {               
                return View("HomePage", userData);
            }
                return RedirectToAction("Index");

            //return View("HomePage", userData);

            }

        public ActionResult LogOut()
        {
            homeBL.ClearSeesion();
            return RedirectToAction("LoginPage","Login");
        }

    }
}