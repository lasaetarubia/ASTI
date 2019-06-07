using ASTI_Helper.Models;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace ASTI_DAL
{
    public class ASTIAdminDAL
    {
        public long GetNewStaffId(Staff staff)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            long staffId = -1;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                var sql = "insert into astaff (sname, loc, dor, pwd) values(@sname, @loc, @dateOfRegistration, @pwd) select SCOPE_IDENTITY()";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@sname", staff.StaffName);
                cmd.Parameters.AddWithValue("@loc", staff.Location);
                cmd.Parameters.AddWithValue("@dateOfRegistration", staff.DateOfRegistration);
                cmd.Parameters.AddWithValue("@pwd", staff.Password);
                con.Open();

                staffId = Convert.ToInt64(cmd.ExecuteScalar());

                con.Close();
            }

            return staffId;
        }
    }
}
