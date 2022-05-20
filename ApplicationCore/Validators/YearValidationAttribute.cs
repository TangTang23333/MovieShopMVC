using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Validators
{
    public class YearValidationAttribute : ValidationAttribute
    {


        public int Year { get; }
        public YearValidationAttribute(int year)
        {
            Year = year;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            var userEnteredYear = ((DateTime)value).Year;

            if (userEnteredYear < Year)
            {

                return new ValidationResult("Please enter correct year");
            }

            return ValidationResult.Success;
        }




    }
}

