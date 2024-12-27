using tp7.Domain.Entities;

namespace tp7.Domain.RepositoryInterfaces
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {
        Task<IEnumerable<Movie>> GetMoviesByGenre(Guid genreId);
    }
}
