using AadharSecureTravelIdentity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AadharSecureTravelIdentity.Controllers
{
    public class AdminController : HomeController
    {
        public ActionResult AdminIndex()
        {
            return View();
        }

        public ActionResult RegisterStaff()
        {
            Staff staff = new Staff();
            staff.DateOfRegistration = DateTime.Today;

            return View(staff);
        }

        [HttpPost]
        public ActionResult RegisterStaff(Staff staff)
        {
            return View("RegistrationSuccessful");
        }

    }
}
