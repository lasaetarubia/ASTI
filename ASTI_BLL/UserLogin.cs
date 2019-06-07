using ASTI_DAL;
using ASTI_Helper;
using ASTI_Helper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASTI_BLL
{
    public class UserLogin
    {
        public bool VerifyLoginCredentials(User user)
        {
            if (string.IsNullOrWhiteSpace(user.UserName) || string.IsNullOrWhiteSpace(user.Password))
                return false;

            var login = new UserLoginDAL();
            return login.VerifyCredentials(user.UserName, user.Password, user.UserType);
        }
    }
}
