using System.ComponentModel.DataAnnotations;

namespace BookHub.Api.Validators
{
    public class NoBadWordsAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (value is string comment && !string.IsNullOrEmpty(comment))
            {
                if (comment.Contains("horrible", StringComparison.OrdinalIgnoreCase))
                {
                    return new ValidationResult($"Comments cannot contain the word horrible.");
                }
            }
            return ValidationResult.Success;
        }
    }
}