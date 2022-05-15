namespace ApplicationCore.Models
{
    public class UserLoggedIn
    {

        public string Email { get; set; }

        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }



        //public byte? TwoFactorEnabled { get; set; }

        //public DateTime? LockoutEndDate { get; set; }

        //public DateTime? LastLoginDateTime { get; set; }

        //public byte? IsLocked { get; set; }
        //public int? AccessFailedCount { get; set; }

        // NAVIGATION 

        //public ICollection<Favorite>? Favorites { get; set; }
        //public ICollection<Purchase>? Purchases { get; set; }
        //public ICollection<Review>? Reviews { get; set; }
        //public ICollection<UserRole>? Roles { get; set; }

    }
}
