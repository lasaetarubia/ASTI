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

        public ActionResult ProcessPendingApplication()
        {
            ASTIAdmin admin = new ASTIAdmin();

            var pendingApplications = admin.GetAllPendingApplications().Where(app => app.IsPending).ToList();

            var applicationModel = new ApplicationViewModel()
            {
                PendingApplications = pendingApplications,
                SelectedApplicationId = 1
            };

            return View(applicationModel);
        }

        [HttpPost]
        public ActionResult ProcessPendingApplication(ApplicationViewModel appModel)
        {
            var selectedApplicationNumber = appModel.SelectedApplicationId;
            var citizenModel = new CitizenViewModel();
            var admin = new ASTIAdmin();

            var pendingCitizen = admin.GetPendingCitizen(selectedApplicationNumber);

            citizenModel.AadharCitizen = pendingCitizen;
            citizenModel.AadharApplication = new Application() { ApplicationNumber = selectedApplicationNumber, DateOfRegistration = DateTime.Now, IsPending = true };

            return View("ProcessCitizen", citizenModel);
        }

    }
}
