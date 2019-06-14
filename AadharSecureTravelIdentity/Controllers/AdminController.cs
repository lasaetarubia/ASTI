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

        public ActionResult Previous()
        {
            TempData["IsFromHome"] = true;
            return RedirectToAction("AdminIndex");
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

            citizenModel.Name = pendingCitizen.Name;
            citizenModel.Address = pendingCitizen.Address;
            citizenModel.Contact = pendingCitizen.Contact;
            citizenModel.DateOfBirth = pendingCitizen.DateOfBirth;
            citizenModel.FatherName = pendingCitizen.FatherName;
            citizenModel.Gender = pendingCitizen.Gender;
            citizenModel.Occupation = pendingCitizen.Occupation;
            citizenModel.ImagePath = pendingCitizen.ImagePath;
            citizenModel.PinCode = pendingCitizen.PinCode;
            citizenModel.SurveyorName = pendingCitizen.SurveyorName;//Should be recieved from DB
            citizenModel.ApplicationNumber = selectedApplicationNumber;
            citizenModel.DateOfRegistration = DateTime.Now;//Should be recieved from DB
            citizenModel.IsPending = true;

            return View("ProcessCitizen", citizenModel);
        }

        [HttpPost]
        public ActionResult ProcessCitizen(CitizenViewModel citizenModel)
        {
            if (citizenModel.SelectedProcess == "Accept")
            {
                var admin = new ASTIAdmin();
                var citizen = new Citizen();

                citizen = admin.GetAadharInformation(citizenModel.ApplicationNumber);

                citizenModel.AadharNumber = citizen.AadharNumber;
                citizenModel.AadharPassword = citizen.AadharPassword;

                return View("UIDAllocation", citizenModel);
            }
            else
            {
                return View("Rejected");
            }
        }

        public ActionResult AllocateUID(CitizenViewModel citizenModel)
        {
            var admin = new ASTIAdmin();

            //Right now not clear about what allocate uid is supposed to do, just making IsPending as false
            admin.AllocateUserId(citizenModel.ApplicationNumber);

            ViewBag.IsUIDAllocated = true;

            return View("UIDAllocation");
        }

        public ActionResult RegisterPincode()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterPincode(PincodeViewModel pincodeModel)
        {
            var admin = new ASTIAdmin();
            var pinCode = new PincodeRegistration();

            pinCode.Area = pincodeModel.Area;
            pinCode.Incharge = pincodeModel.Incharge;
            pinCode.Location = pincodeModel.Location;
            pinCode.Password = pincodeModel.Password;
            pinCode.Pincode = pincodeModel.Pincode;
            pinCode.StationName = pincodeModel.StationName;
            pinCode.StationType = pincodeModel.StationType;

            var pinCodeId = admin.RegisterPinCode(pinCode);

            ViewBag.IsPincodeRegistered = true;
            return View();
        }
    }
}
