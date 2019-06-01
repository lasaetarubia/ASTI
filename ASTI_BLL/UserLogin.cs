using ASTI_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASTI_BLL
{
    public class UserLogin
    {
        public bool VerifyLoginCredentials(string userName, string password)
        {
            var login = new UserLoginDAL();
            return login.VerifyCredentials(userName, password);
        }
    }
}
