using AadharSecureTravelIdentity.Models;
using ASTI_BLL;
using ASTI_Helper.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            var selectedAadharNumber = licenseModel.SelectedId;
            var citizenModel = new CitizenViewModel();
            var rta = new ASTIRTA();

            var pendingCitizen = rta.GetLicensePendingCitizen(selectedAadharNumber);

            citizenModel.Name = pendingCitizen.Name;
            citizenModel.Address = pendingCitizen.Address;
            citizenModel.Contact = pendingCitizen.Contact;
            citizenModel.DateOfBirth = pendingCitizen.DateOfBirth;
            citizenModel.FatherName = pendingCitizen.FatherName;
            citizenModel.Gender = pendingCitizen.Gender;
            citizenModel.Occupation = pendingCitizen.Occupation;
            citizenModel.ImagePath = pendingCitizen.ImagePath;
            citizenModel.PinCode = pendingCitizen.PinCode;
            citizenModel.SurveyorName = pendingCitizen.SurveyorName;
            citizenModel.ApplicationNumber = pendingCitizen.ApplicationId;
            citizenModel.DateOfRegistration = DateTime.Now;//Should be recieved from DB
            citizenModel.IsPending = pendingCitizen.IsPending;
            citizenModel.IsLicensePending = pendingCitizen.IsLicensePending;
            citizenModel.AadharNumber = pendingCitizen.AadharNumber;

            return View("CitizenProfile", citizenModel);
        }

        [HttpPost]
        public ActionResult ProcessCitizenProfile(CitizenViewModel citizenViewModel)
        {
            var citizen = new Citizen();

            citizen.AadharNumber = citizenViewModel.AadharNumber;
            citizen.ApplicationId = citizenViewModel.ApplicationNumber;
            citizen.SurveyorName = citizenViewModel.SurveyorName;
            citizen.VehicleType = (int)citizenViewModel.VehicleType;
            citizen.Venue = citizenViewModel.Venue;
            citizen.ReportingDate = DateTime.Parse(citizenViewModel.ReportingDate).Date;
            DateTime dt;
            if (!DateTime.TryParseExact(citizenViewModel.ReportingTime, "HH:mm", CultureInfo.InvariantCulture,
                                                          DateTimeStyles.None, out dt))
            {
                // handle validation error
            }
            citizen.ReportingTime = dt.TimeOfDay;

            var rtaBll = new ASTIRTA();

            rtaBll.ProcessCitizenProfile(citizen);

            return View(citizenViewModel);
        }

        public ActionResult DeclareResult()
        {
            return View();
        }

    }
}
