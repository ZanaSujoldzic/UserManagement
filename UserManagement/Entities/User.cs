using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace UserManagement.Models
{
    public partial class User : IdentityUser
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; } 
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Status { get; set; }
        public int CodeId { get; set; }
    }
}
