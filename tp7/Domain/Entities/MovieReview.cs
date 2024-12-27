using System.ComponentModel.DataAnnotations;

namespace tp7.Domain.Entities
{
    public class MovieReview
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "The movie review is required.")]
        [StringLength(2000, ErrorMessage = "The movie review must be at most 2000 characters.")]
        public string Comment { get; set; } = "";

        [Range(0, 5, ErrorMessage = "The rating must be between 0 and 5.")]
        public int Rating { get; set; } = 0;
        public Movie Movie { get; set; } = null!;

        public Guid MovieId { get; set; }
        public Customer Customer { get; set; } = null!;
        public Guid CustomerId { get; set; }
    }
}
