using AadharSecureTravelIdentity.Models;
using ASTI_BLL;
using ASTI_Helper;
using ASTI_Helper.Models;
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
        public ActionResult Index(UserViewModel userModel)
        {
            var userLogin = new UserLogin();
            var user = new User();

            user.UserName = userModel.UserName;
            user.Password = userModel.Password;
            user.UserType = userModel.UserType;

            var isLoggedIn = userLogin.VerifyLoginCredentials(user);

            if (isLoggedIn)
            {
                Session["UserName"] = Convert.ToString(user.UserName);
                Session["UserType"] = Enum.Parse(typeof(UserType), Convert.ToString(user.UserType));
                switch (user.UserType)
                {
                    case ASTI_Helper.UserType.Admin:
                        TempData["IsFromHome"] = true;
                        return RedirectToAction("AdminIndex", "Admin");
                    default:
                        return RedirectToAction("Index");
                }
            }

            return View();
        }

        public ActionResult ChangePassword()
        {  
            TempData["IsFromHome"] = true;
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(UserViewModel userModel)
        {
            userModel.UserName = Convert.ToString(Session["UserName"]);
            userModel.UserType = (UserType)Enum.Parse(typeof(UserType), Convert.ToString(Session["UserType"]));

            var userLogin = new UserLogin();
            var user = new User();

            user.UserName = userModel.UserName;
            user.Password = userModel.Password;
            user.UserType = userModel.UserType;

            var isPasswordChanged = userLogin.ChangePassword(user);

            ViewBag.IsPasswordChanged = true;
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }

    }
}
