using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using UserManagement.Models;

namespace UserManagement.Dto
{
    public class RoleModificationDto
    {
        [Required]
        public string RoleName { get; set; }

        public string RoleId { get; set; }

        public string[]? AddIds { get; set; }

        public string[]? DeleteIds { get; set; }
    }
}
