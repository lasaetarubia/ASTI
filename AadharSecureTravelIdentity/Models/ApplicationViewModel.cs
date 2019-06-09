using ASTI_Helper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AadharSecureTravelIdentity.Models
{
    public class ApplicationViewModel
    {
        public List<Application> PendingApplications { get; set; }

        public int SelectedApplicationId { get; set; }
    }
}