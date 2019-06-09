using ASTI_Helper;
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

        public Citizen GetPendingCitizen(int appNum)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            Citizen citizen = new Citizen();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                var sql = "select * from citizenregn where appno = @appno";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@appno", appNum);
                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        citizen.Name = Convert.ToString(reader["cname"]);
                        citizen.Address = Convert.ToString(reader["caddr"]);
                        citizen.DateOfBirth = Convert.ToDateTime(reader["dob"]);
                        citizen.FatherName = Convert.ToString(reader["fname"]);
                        citizen.Contact = Convert.ToString(reader["cno"]);
                        citizen.Occupation = Convert.ToString(reader["occ"]);
                        citizen.Photo = Convert.ToString(reader["ph"]);
                        citizen.PinCode = Convert.ToInt32(reader["pin"]);
                        citizen.Gender = (Gender)Enum.Parse(typeof (Gender),Convert.ToString((reader["gend"])));
                    }
                }
            }

            return citizen;
        }
    }
}
