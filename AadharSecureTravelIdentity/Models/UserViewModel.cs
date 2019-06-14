using ASTI_Helper;
using ASTI_Helper.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AadharSecureTravelIdentity.Models
{
    public class UserViewModel
    {
        [Required(ErrorMessage="UserName is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirmation Password is required.")]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        [NotMapped]
        public string ConfirmPassword { get; set; }

        public UserType UserType { get; set; }
    }
}