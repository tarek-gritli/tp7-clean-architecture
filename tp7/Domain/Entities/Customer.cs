using System.ComponentModel.DataAnnotations;

namespace tp7.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "The customer name is required.")]
        [StringLength(255, ErrorMessage = "The customer name must be at most 255 characters.")]
        public string Name { get; set; } = "";
        public ICollection<Movie> Movies { get; set; } = [];
        public ICollection<MovieReview> Reviews { get; set; } = [];
    }
}
