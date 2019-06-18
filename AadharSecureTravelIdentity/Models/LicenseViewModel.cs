using ASTI_Helper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AadharSecureTravelIdentity.Models
{
    public class LicenseViewModel
    {
        public List<Citizen> PendingCitizen { get; set; }

        public int SelectedId { get; set; }
    }
}