using ASTI_Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASTI_DAL
{
    public class UserLoginDAL
    {
        public bool VerifyCredentials(string userName, string password, UserType userType)
        {
            var isCorrectLogin = false;
            var sql = string.Empty;
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                sql = GetConnectionBasedOnUserType(userType, sql);

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@uid", userName);
                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (string.Equals(password, Convert.ToString(reader["pwd"])))
                        {
                            isCorrectLogin = true;
                            break;
                        }
                    }

                    con.Close();
                }
            }
            return isCorrectLogin;
        }

        private static string GetConnectionBasedOnUserType(UserType userType, string sql)
        {
            switch (userType)
            {
                case UserType.Admin:
                    sql = "select * from admin where uid = @uid";
                    break;
                case UserType.RTA:
                    sql = "select * from pinmast where station = @uid";
                    break;
                case UserType.Citizen:
                    sql = "Select query here";
                    break;
                case UserType.Staff:
                    sql = "Select query here";
                    break;
                default:
                    sql = string.Empty;
                    break;
            }
            return sql;
        }

        public bool ChangePassword(ASTI_Helper.Models.User user)
        {
            var result = -1;
            var sql = string.Empty;
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                sql = ChangePasswordBasedOnUserType(user.UserType, sql);

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@uid", user.UserName);
                cmd.Parameters.AddWithValue("@pwd", user.Password);                
                con.Open();

                result = cmd.ExecuteNonQuery();
            }

            return result > 0;
        }

        private static string ChangePasswordBasedOnUserType(UserType userType, string sql)
        {
            switch (userType)
            {
                case UserType.Admin:
                    sql = "update admin set pwd = @pwd where uid = @uid";
                    break;
                case UserType.RTA:
                    sql = "update pinmast set pwd = @pwd where station = @uid";
                    break;
                case UserType.Citizen:
                    sql = "Select query here";
                    break;
                case UserType.Staff:
                    sql = "Select query here";
                    break;
                default:
                    sql = string.Empty;
                    break;
            }
            return sql;
        }
    }
}
