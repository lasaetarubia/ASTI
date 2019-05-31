using AadharSecureTravelIdentity.Models;
using ASTI_BLL;
using System;
using System.Web.Mvc;

namespace AadharSecureTravelIdentity.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            //Only a simple login method right now to show the code flow

            var userLogin = new UserLogin();

            var isLoggedIn = userLogin.VerifyLoginCredentials(user.UserName, user.Password);

            if (isLoggedIn)
            {
                Session["UserName"] = Convert.ToString(user.UserName);
                return RedirectToAction("AfterLogin");
            }

            return View();
        }

        public ActionResult AfterLogin()
        {
            if (Session["UserName"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }  
        }
    }
}
