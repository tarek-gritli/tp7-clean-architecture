using System.ComponentModel.DataAnnotations;

namespace tp7.Application.DTOs
{
    public class MovieDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The movie name is required.")]
        [StringLength(200, ErrorMessage = "The movie name must be at most 200 characters.")]
        public string Name { get; set; } = "";

        public GenreDTO Genre { get; set; } = new GenreDTO();

        public IEnumerable<MovieReviewDTO>? Reviews { get; set; } = [];
    }
}
