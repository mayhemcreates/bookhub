using System.ComponentModel.DataAnnotations;

namespace BookHub.Api.Validators
{
    public class NoBadWordsAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var badWords = new[] { "bad", "awful", "terrible" };
            if (value is string comment && !string.IsNullOrEmpty(comment))
            {
                foreach (var badWord in badWords)
                {
                    if (comment.Contains(badWord, StringComparison.OrdinalIgnoreCase))
                    {
                        return new ValidationResult($"Comments cannot contain the word '{badWord}'.");
                    }
                }
            }
            return ValidationResult.Success;
        }
    }
}