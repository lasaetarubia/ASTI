using ASTI_Helper;
using ASTI_Helper.Models;
using System.ComponentModel.DataAnnotations;

namespace AadharSecureTravelIdentity.Models
{
    public class UserViewModel
    {
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirmation Password is required.")]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        public string ConfirmPassword { get; set; }

        public UserType UserType { get; set; }
    }
}