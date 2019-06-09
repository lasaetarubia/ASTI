using ASTI_Helper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AadharSecureTravelIdentity.Models
{
    public class CitizenViewModel
    {
        public Citizen AadharCitizen { get; set; }

        public Application AadharApplication { get; set; }
    }
}