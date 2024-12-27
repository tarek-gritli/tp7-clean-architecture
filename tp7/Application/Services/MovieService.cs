using AutoMapper;
using tp7.Application.DTOs;
using tp7.Application.Interfaces;
using tp7.Domain.RepositoryInterfaces;

namespace tp7.Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MovieDTO>> GetMoviesByGenre(Guid genreId)
        {
            var movies = await _movieRepository.GetMoviesByGenre(genreId);
            return _mapper.Map<IEnumerable<MovieDTO>>(movies);
        }

        public async Task<double> GetMovieAverageRating(Guid movieId)
        {
            var movie = await _movieRepository.GetById(movieId);
            if (movie == null)
            {
                throw new Exception("Movie not found");
            }

            return movie.Reviews.Count > 0 ? movie.Reviews.Average(r => r.Rating) : 0;
        }
    }
}
