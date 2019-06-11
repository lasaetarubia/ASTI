using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASTI_Helper.Models
{
    public class Citizen
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

        public int AadharNumber { get; set; }

        public string AadharPassword { get; set; }

    }
}
