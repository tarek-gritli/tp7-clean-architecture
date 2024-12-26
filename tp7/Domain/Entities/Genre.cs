using System.ComponentModel.DataAnnotations;

namespace tp7.Domain.Entities
{
    public class Genre
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "The genre name is required.")]
        [StringLength(100, ErrorMessage = "The genre name must be at most 100 characters.")]
        public string Name { get; set; } = "";

        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
