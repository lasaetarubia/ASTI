using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AadharSecureTravelIdentity.Models
{
    public class Staff
    {
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public string Password { get; set; }
        public string Location { get; set; }
        public DateTime DateOfRegistration { get; set; }
    }
}