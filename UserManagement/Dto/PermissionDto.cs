using UserManagement.Models;

namespace UserManagement.Dto
{
    public class PermissionDto
    {
        public int CodeId { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
        public DateTime? DateCreated { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
