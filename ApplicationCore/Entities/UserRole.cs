using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities
{
    public class UserRole
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int RoleId { get; set; }

        // navigation property
        public Role Role { get; set; }
        public User User { get; set; }
    }
}
