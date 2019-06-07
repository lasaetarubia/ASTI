using AadharSecureTravelIdentity.Models;
using ASTI_BLL;
using ASTI_Helper.Models;
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
            var staffModel = new StaffViewModel
            {
                AadharStaff = new Staff()
            };

            staffModel.AadharStaff.DateOfRegistration = DateTime.Today;

            return View(staffModel);
        }

        [HttpPost]
        public ActionResult RegisterStaff(StaffViewModel staffModel)
        {
            ASTIAdmin admin = new ASTIAdmin();

            var staffId = admin.GetNewStaffId(staffModel.AadharStaff);
            if (staffId > 0)
            {
                staffModel.AadharStaff.StaffId = staffId;
                return View("RegistrationSuccessful", staffModel);
            }
            else
                return View("Error");
        }

    }
}
