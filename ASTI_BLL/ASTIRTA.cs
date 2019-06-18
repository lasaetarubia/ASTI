using ASTI_DAL;
using ASTI_Helper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASTI_BLL
{
    public class ASTIRTA
    {
        public List<Citizen> GetPendingLicenseApplications()
        {
            var rta = new ASTIRTADAL();
            return rta.GetPendingLicenseApplications().Where(license => license.IsLicensePending == "1").ToList();
        }
    }
}
