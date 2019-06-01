using ASTI_Helper;
using System.ComponentModel.DataAnnotations;

namespace AadharSecureTravelIdentity.Models
{
    public class User
    {
        [Required(ErrorMessage = "Please enter the user name", AllowEmptyStrings = false)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter the password", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public UserType UserType { get; set; }
    }
}