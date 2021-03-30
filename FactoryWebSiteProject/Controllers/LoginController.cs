using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FactoryWebSiteProject.Models;

namespace FactoryWebSiteProject.Controllers
{
    public class LoginController : Controller
    {
        public int counter = 0;
        HomeBL homeBL = new HomeBL();
    

        public ActionResult LoginPage(User user)
        {
          
                return View("LoginPage");
        }

        public ActionResult DoLogin(User user)
        {
            Session["counter"] = -1;
            
            var resul = homeBL.IsUserExist(user);
            if (resul)
            {
                
                Session["isUsedAllAction"] = false;
                return RedirectToAction("HomePage", "Home");               
            }

            return RedirectToAction("LoginPage");
        }
        public ActionResult RegistrationPage()
        {
            return View("RegistrationPage");
        }
        public ActionResult GetNewUser(User user)
        {
            homeBL.AddUser(user);

            return RedirectToAction("Index");
        }
    }
}