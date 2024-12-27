using tp7.Domain.Entities;

namespace tp7.Domain.RepositoryInterfaces
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<IEnumerable<Movie>> GetFavoriteMovies(Guid customerId);
        Task<IEnumerable<MovieReview>> GetMovieReviews(Guid customerId);
    }
}
