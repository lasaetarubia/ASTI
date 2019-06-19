using ASTI_Helper;
using ASTI_Helper.Models;
using System;
using System.Collections.Generic;
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
                        citizen.ImagePath = Convert.ToString(reader["ph"]);
                        citizen.PinCode = Convert.ToInt32(reader["pin"]);
                        citizen.Gender = (Gender)Enum.Parse(typeof(Gender), Convert.ToString((reader["gend"])));
                        citizen.AadharNumber = Convert.ToInt32(reader["ano"]);
                        citizen.AadharPassword = Convert.ToString(reader["apwd"]);
                        citizen.IsLicensePending = Convert.ToString(reader["islicensepending"]);
                        citizen.IsPending = Convert.ToString(reader["IsPending"]);
                    }
                }
            }

            return citizen;
        }

        public Citizen GetLicensePendingCitizen(int aadharNumber)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            Citizen citizen = new Citizen();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                var sql = "select * from citizenregn where ano = @ano";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ano", aadharNumber);
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
                        citizen.ImagePath = Convert.ToString(reader["ph"]);
                        citizen.PinCode = Convert.ToInt32(reader["pin"]);
                        citizen.Gender = (Gender)Enum.Parse(typeof(Gender), Convert.ToString((reader["gend"])));
                        citizen.ApplicationId = Convert.ToInt32(reader["appno"]);
                        citizen.AadharNumber = Convert.ToInt32(reader["ano"]);
                        citizen.AadharPassword = Convert.ToString(reader["apwd"]);
                        citizen.IsLicensePending = Convert.ToString(reader["islicensepending"]);
                        citizen.IsPending = Convert.ToString(reader["IsPending"]);
                    }
                }
            }

            return citizen;
        }

        public List<Citizen> GetAllCitizens()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            Citizen citizen = new Citizen();
            var citizenList = new List<Citizen>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                var sql = "select * from citizenregn";

                SqlCommand cmd = new SqlCommand(sql, con);
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
                        citizen.ImagePath = Convert.ToString(reader["ph"]);
                        citizen.PinCode = Convert.ToInt32(reader["pin"]);
                        citizen.Gender = (Gender)Enum.Parse(typeof(Gender), Convert.ToString((reader["gend"])));
                        citizen.AadharNumber = Convert.ToInt32(reader["ano"]);
                        citizen.AadharPassword = Convert.ToString(reader["apwd"]);
                        citizen.IsPending = Convert.ToString(reader["IsPending"]);
                        citizen.IsLicensePending = Convert.ToString(reader["islicensepending"]);
                        citizen.ApplicationId = Convert.ToInt32(reader["appno"]);

                        citizenList.Add(citizen);
                    }
                }
            }

            return citizenList;
        }

        public Citizen GetAadharInformation(int appNum)
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
                        citizen.AadharNumber = Convert.ToInt32(reader["ano"]);
                        citizen.AadharPassword = Convert.ToString(reader["apwd"]);
                    }
                }
            }
            return citizen;
        }

        public void AllocateUserId(int appNum)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            Citizen citizen = new Citizen();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                var sql = "update citizenregn set ispending = 0 where appno = @appno";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@appno", appNum);
                con.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public int RegisterPinCode(PincodeRegistration pinCode)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            var pincodeId = -1;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                var sql = "insert into pinmast (station, loc, inc, pwd, pinc, area, stype) values(@station, @loc, @incharge, @pwd, @pincode, @area, @stationType) select SCOPE_IDENTITY()";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@station", pinCode.StationName);
                cmd.Parameters.AddWithValue("@loc", pinCode.Location);
                cmd.Parameters.AddWithValue("@incharge", pinCode.Incharge);
                cmd.Parameters.AddWithValue("@pwd", pinCode.Password);
                cmd.Parameters.AddWithValue("@pincode", pinCode.Pincode);
                cmd.Parameters.AddWithValue("@area", pinCode.Area);
                cmd.Parameters.AddWithValue("@stationType", pinCode.StationType);
                con.Open();

                pincodeId = Convert.ToInt32(cmd.ExecuteScalar());

                con.Close();
            }

            return pincodeId;
        }
    }
}
