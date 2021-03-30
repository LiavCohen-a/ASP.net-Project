using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FactoryWebSiteProject.Models
{

    public class HomeBL
    {
        FactoryDBEntities db = new FactoryDBEntities();

        public bool IsUserExist(User user)
        {
           
            var result1 = db.User.Where(x=> x.UserName == user.UserName && x.Password == user.Password).SingleOrDefault();
         
            
           if(result1 != null)
            {
                HttpContext.Current.Session["date"] = DateTime.Today.ToString();
                var data = HttpContext.Current.Session["userData"];
                var today = HttpContext.Current.Session["date"];
                var now = DateTime.Today.ToString();
                if ((User)data == null || (string)today != now)
                {
                    HttpContext.Current.Session["isAuth"] = true;
                    HttpContext.Current.Session["userData"] = result1;
                    HttpContext.Current.Session["NumOfActions"] = result1.NumOfAction;
                    HttpContext.Current.Session["islogdin"] = false;

                }
                else
                {
                    
                    HttpContext.Current.Session["islogdin"] = true;
                }

               return true;
            }
            else
            {

                return false;
            }
        }
     


        public void ClearSeesion()
        {
            HttpContext.Current.Session.Clear();
           
        }
        public void AddUser(User user)
        {
            db.User.Add(user);
            db.SaveChanges();
        }

        public string UserName(User user)
        {
           var result =  db.User.Where(x => x.UserName == user.UserName && x.Password == user.Password).First();
            return result.FullName;
        }
        

        public User GetUserData()
        {
            var isLoggedIn = HttpContext.Current.Session["isAuth"];
            var userData = HttpContext.Current.Session["userData"];
            var NumOfActions = HttpContext.Current.Session["NumOfActions"];
            var use = HttpContext.Current.Session["isUsedAllAction"];
            var counter = HttpContext.Current.Session["counter"];
            var isalredy = HttpContext.Current.Session["islogdin"];


            if (isLoggedIn != null && (bool)isalredy == false)
            {
                if ((int)NumOfActions > (int)counter + 1 && (bool)use ==false)
                {
                    HttpContext.Current.Session["counter"] = (int)counter + 1;
                        return userData as User; 
                }
                else
                {
                    HttpContext.Current.Session["isUsedAllAction"] = true;
                    return null;
                }
            }
            else
            {
                HttpContext.Current.Session["isAuth"] = false;
              
                return null;
            }
          
        }
       
    }
}