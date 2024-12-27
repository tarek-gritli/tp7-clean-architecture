using Microsoft.EntityFrameworkCore;
using tp7.Domain.Entities;
using tp7.Domain.RepositoryInterfaces;

namespace tp7.Infrastructure.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        private readonly ApplicationDbContext _db;

        public MovieRepository(ApplicationDbContext context)
            : base(context)
        {
            _db = context;
        }

        public async Task<IEnumerable<Movie>> GetMoviesByGenre(Guid genreId)
        {
            return await _db
                .Movies.Where(m => m.GenreId == genreId)
                .Include(m => m.Genre)
                .Include(m => m.Reviews)
                .ToListAsync();
        }
    }
}
