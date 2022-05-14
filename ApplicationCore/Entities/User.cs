using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    [Table("User")]
    public class User
    {
        [Required]
        public int Id { get; set; }
        [MaxLength(128)]

        public string? FirstName { get; set; }
        [MaxLength(128)]
        public string? LastName { get; set; }
        [Column(TypeName = "datetime2(7)")]
        public DateTime? DateOfBirth { get; set; }
        [MaxLength(256)]
        public string? Email { get; set; }
        [MaxLength(1024)]

        public string? HashedPassword { get; set; }
        [MaxLength(1024)]
        public string? Salt { get; set; }
        [MaxLength(16)]
        public string? PhoneNumber { get; set; }

        public byte? TwoFactorEnabled { get; set; }
        [Column(TypeName = "datetime2(7)")]
        public DateTime? LockoutEndDate { get; set; }
        [Column(TypeName = "datetime2(7)")]
        public DateTime? LastLoginDateTime { get; set; }

        public byte? IsLocked { get; set; }
        public int? AccessFailedCount { get; set; }

        // NAVIGATION 

        public ICollection<Favorite>? Favorites { get; set; }
        public ICollection<Purchase>? Purchases { get; set; }
        public ICollection<Review>? Reviews { get; set; }
        public ICollection<UserRole>? Roles { get; set; }

    }

}
