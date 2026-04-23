using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class Role
    {
        public int RoleId { get; set; }

        [Required]
        [MaxLength(100)]
        public string RoleName { get; set; } = string.Empty;

        // user-role relations
        public ICollection<UserRole>? UserRoles { get; set; }
    }
}
