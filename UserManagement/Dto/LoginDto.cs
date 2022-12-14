using Duende.IdentityServer.Models;
using Nest;
using System.ComponentModel.DataAnnotations;

namespace UserManagement.Dto
{
    public class LoginDto
    {

        [Required(ErrorMessage = "Email is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}
