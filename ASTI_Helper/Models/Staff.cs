using System;

namespace ASTI_Helper.Models
{
    public class Staff
    {
        public long StaffId { get; set; }
        public string StaffName { get; set; }
        public string Password { get; set; }
        public string Location { get; set; }
        public DateTime DateOfRegistration { get; set; }
    }
}
