using AadharSecureTravelIdentity.Models;
using ASTI_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AadharSecureTravelIdentity.Controllers
{
    public class RTAController : Controller
    {
        public ActionResult RTAIndex()
        {
            return View();
        }

        public ActionResult ScheduleLicenseApplication()
        {
            ASTIRTA rta = new ASTIRTA();
            var pendingApplications = rta.GetPendingLicenseApplications();

            var licenseModel = new LicenseViewModel()
            {
                PendingCitizen = pendingApplications,
                SelectedId = 1
            };

            return View(licenseModel);
        }

        [HttpPost]
        public ActionResult ScheduleLicenseApplication(LicenseViewModel licenseModel)
        {
            return View("CitizenProfile");
        }

        public ActionResult DeclareResult()
        {
            return View();
        }

    }
}
