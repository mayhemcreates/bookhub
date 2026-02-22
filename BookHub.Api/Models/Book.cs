using System.ComponentModel.DataAnnotations;
using BookHub.Api.Validators;

namespace BookHub.Api.Models
{

    public class Book
    {
        [Required]
        [StringLength(100)]
        public string Title { get; init; }

        [Required]
        [StringLength(100)]
        public string Author { get; init; }

        [Required]
        [StringLength(13)]
        [RegularExpression(@"^\d{10}(\d{3})?$", ErrorMessage = "Isbn must be 10 or 13 digits")]
        public string ISBN { get; init; }

        [Range(1, 5)]
        public int? Rating { get; set; }

        [Required]
        public bool NoteStatus { get; set; } = false;

        [RequiredIfRatingSupplied]
        [StringLength(400)]
        [NoBadWords]
        public string Comments { get; set; }

        [Required]
        public string ImageUrl { get; init; }

        [Required]
        public int Id { get; set; }
    }
}