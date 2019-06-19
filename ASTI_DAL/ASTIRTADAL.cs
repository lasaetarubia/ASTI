using ASTI_Helper.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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

        public void ProcessCitizenProfile(Citizen citizen)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                var sql = "update citizenregn set islicensepending = 0, vehicletype = @vtype, venue = @venue, reportTo = @surveyor, reportingDate = @rdate, reportingTime = @rTime where ano = @aadhar";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@vtype", citizen.VehicleType);
                cmd.Parameters.AddWithValue("@venue", citizen.Venue);
                cmd.Parameters.AddWithValue("@surveyor", citizen.SurveyorName);
                cmd.Parameters.AddWithValue("@rdate", citizen.ReportingDate);
                cmd.Parameters.AddWithValue("@rTime", citizen.ReportingTime);                
                cmd.Parameters.AddWithValue("@aadhar", citizen.AadharNumber);
                con.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}
