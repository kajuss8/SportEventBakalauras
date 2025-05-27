using System.ComponentModel.DataAnnotations;

namespace SportEventsApp.Attributes
{
    public class DateOfBirthAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateOnly dateOfBirth)
            {
                var today = DateOnly.FromDateTime(DateTime.Today);
                var minDate = today.AddYears(-100);

                if (dateOfBirth > today)
                {
                    return new ValidationResult("Date of Birth cannot be in the future.");
                }

                if (dateOfBirth < minDate)
                {
                    return new ValidationResult("Date of Birth cannot be more than 100 years ago.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
