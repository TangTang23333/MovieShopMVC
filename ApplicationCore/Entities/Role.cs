using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities
{
    public class Role
    {
        [Required]
        public int Id { get; set; }
        [MaxLength(20)]
        public string? Name { get; set; }

        //

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
