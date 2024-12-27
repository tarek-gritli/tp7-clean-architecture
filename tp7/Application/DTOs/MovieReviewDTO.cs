using System.ComponentModel.DataAnnotations;

namespace tp7.Application.DTOs
{
    public class MovieReviewDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The movie review is required.")]
        [StringLength(2000, ErrorMessage = "The movie review must be at most 2000 characters.")]
        public string Comment { get; set; } = "";

        [Range(0, 5, ErrorMessage = "The rating must be between 0 and 5.")]
        public int Rating { get; set; } = 0;

        public Guid MovieId { get; set; }

        public Guid CustomerId { get; set; }
    }
}
