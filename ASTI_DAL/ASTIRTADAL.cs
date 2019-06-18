using ASTI_Helper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASTI_DAL
{
    public class ASTIRTADAL
    {
        public List<Citizen> GetPendingLicenseApplications()
        {
            ASTIAdminDAL admin = new ASTIAdminDAL();
            return admin.GetAllCitizens();
        }
    }
}
