using tp7.Application.DTOs;
using tp7.Application.Interfaces;
using tp7.Domain.RepositoryInterfaces;

namespace tp7.Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<MovieDTO>> GetMoviesByGenre(Guid genreId)
        {
            var movies = await _movieRepository.GetMoviesByGenre(genreId);
            return movies.Select(m => new MovieDTO
            {
                Id = m.Id,
                Name = m.Name,
                Genre = new GenreDTO { Id = m.Genre.Id, Name = m.Genre.Name },
                Reviews = m
                    .Reviews.Select(r => new MovieReviewDTO
                    {
                        Id = r.Id,
                        Rating = r.Rating,
                        Comment = r.Comment,
                    })
                    .ToList(),
            });
        }
    }
}
