using ASTI_DAL;
using ASTI_Helper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASTI_BLL
{
    public class ASTIAdmin
    {
        public long GetNewStaffId(Staff staff)
        {
            long staffId = -1;
            var admin = new ASTIAdminDAL();

            if (string.IsNullOrWhiteSpace(staff.StaffName) || string.IsNullOrWhiteSpace(staff.Password))
                return staffId;

            //Resetting DateOfRegistration as we are not posting its value from view because that does not seem very useful
            staff.DateOfRegistration = DateTime.Today;

            staffId = admin.GetNewStaffId(staff);

            return staffId;
        }

        public List<Application> GetAllPendingApplications()
        {
            var applications = new List<Application> { 
                new Application { ApplicationNumber = 1, DateOfRegistration = DateTime.Now, IsPending = true },
                new Application { ApplicationNumber = 2, DateOfRegistration = DateTime.Now, IsPending = false },
                new Application { ApplicationNumber = 3, DateOfRegistration = DateTime.Now, IsPending = true },
                new Application { ApplicationNumber = 4, DateOfRegistration = DateTime.Now, IsPending = false },
                new Application { ApplicationNumber = 5, DateOfRegistration = DateTime.Now, IsPending = true }
            };

            var pendingApplications = applications.Where(app => app.IsPending).ToList();

            return pendingApplications;
        }

        public Citizen GetPendingCitizen(int appNum)
        {
            var admin = new ASTIAdminDAL();

            return admin.GetPendingCitizen(appNum);
        }
    }
}
