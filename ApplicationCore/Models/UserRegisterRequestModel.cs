using ApplicationCore.Validators;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models
{

    public class UserRegisterRequestModel
    {
        [Required(ErrorMessage = "Firstname address can not be empty!")]
        [StringLength(100)]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Lastname address can not be empty!")]
        [StringLength(100)]
        public string Lastname { get; set; }
        [Required]
        [DataType(DataType.Date)]
        // 1900-2016
        [YearValidation(1920)]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Email address can not be empty!")]
        [EmailAddress(ErrorMessage = "Email address should be in right format!")]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        //[RegularExpression(@"^[a-zA-Z''-'\s]{8,}$", ErrorMessage = "Password should have at least one number, one lowercase and one uppercase, total length > 8")]
        // >= 8 char, >= 1upper 1 lower 1 num, strong password
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }

    }


}

