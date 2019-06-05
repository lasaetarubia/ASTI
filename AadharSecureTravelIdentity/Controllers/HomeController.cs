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
            var userLogin = new UserLogin();

            var isLoggedIn = userLogin.VerifyLoginCredentials(user.UserName, user.Password, user.UserType);

            if (isLoggedIn)
            {
                Session["UserName"] = Convert.ToString(user.UserName);
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
    }
}
