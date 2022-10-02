using Microsoft.AspNetCore.Identity;
using UserManagement.Models;

namespace UserManagement.Dto
{
    public class RoleEditDto
    {
        public IdentityRole? Role { get; set; }
        public IEnumerable<User>? Members { get; set; }
        public IEnumerable<User>? NonMembers { get; set; }
    }
}
