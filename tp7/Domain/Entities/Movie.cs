using System.ComponentModel.DataAnnotations;

namespace tp7.Domain.Entities
{
    public class Movie
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "The movie name is required.")]
        [StringLength(200, ErrorMessage = "The movie name must be at most 200 characters.")]
        public string Name { get; set; } = "";

        public Guid GenreId { get; set; }
        public Genre Genre { get; set; } = null!;

        public ICollection<Customer> Customers { get; set; } = new List<Customer>();
        public ICollection<MovieReview> Reviews { get; set; } = new List<MovieReview>();
    }
}
