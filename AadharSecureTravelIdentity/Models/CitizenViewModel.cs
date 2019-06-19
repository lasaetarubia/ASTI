using ASTI_Helper;
using ASTI_Helper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AadharSecureTravelIdentity.Models
{
    public class CitizenViewModel
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string FatherName { get; set; }

        public string Contact { get; set; }

        public string Occupation { get; set; }

        public string ImagePath { get; set; }

        public int PinCode { get; set; }

        public Gender Gender { get; set; }

        public string SurveyorName { get; set; }

        public int ApplicationNumber { get; set; }

        public DateTime DateOfRegistration { get; set; }

        public string IsPending { get; set; }

        public string IsLicensePending { get; set; }

        public string SelectedProcess { get; set; }

        public int AadharNumber { get; set; }

        public string AadharPassword { get; set; }

        public VehicleType VehicleType { get; set; }

        public string Venue { get; set; }

        public string ReportingDate { get; set; }

        public string ReportingTime { get; set; }
    }
}