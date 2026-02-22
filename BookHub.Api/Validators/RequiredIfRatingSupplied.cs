using System.ComponentModel.DataAnnotations;
using BookHub.Api.Models;
    
namespace BookHub.Api.Validators
{
    public class RequiredIfRatingSuppliedAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var book = (Book)validationContext.ObjectInstance;

            if (book.Rating.HasValue && string.IsNullOrWhiteSpace(value as string))
            {
                return new ValidationResult("Comments are required when a rating is provided.");
            }

            return ValidationResult.Success;
        }
    }
}
