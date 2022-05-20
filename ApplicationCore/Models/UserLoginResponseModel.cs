namespace ApplicationCore.Models
{
    public class UserLoginResponseModel
    {



        public int? Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        public string? Email { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public bool? TwoFactorEnabled { get; set; }

        public DateTime? LockoutEndDate { get; set; }

        public DateTime? LastLoginDateTime { get; set; }

        public bool? IsLocked { get; set; }
        public int? AccessFailedCount { get; set; }


        //public List<MovieCardModel> Favorites { get; set; }
        //public List<MovieCardModel> Purchased { get; set; }
        //public List<ReviewModel> Reviews { get; set; }
        //public List<RoleModel> Roles { get; set; }

    }


}
