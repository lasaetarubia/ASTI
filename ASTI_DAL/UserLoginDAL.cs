using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASTI_DAL
{
    public class UserLoginDAL
    {
        public bool VerifyCredentials(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
                return false;

            //This part would hopefully be more secure 
            if (userName == "admin" && password == "pass123")
                return true;
            else
                return false;
        }
    }
}
