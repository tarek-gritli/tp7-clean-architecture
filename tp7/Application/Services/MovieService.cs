using AutoMapper;
using tp7.Application.DTOs;
using tp7.Application.Interfaces;
using tp7.Domain.Entities;
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
            try
            {
                var movies = await _movieRepository.GetMoviesByGenre(genreId);
                return _mapper.Map<IEnumerable<MovieDTO>>(movies);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving movies by genre", ex);
            }
        }

        public async Task<double> GetMovieAverageRating(Guid movieId)
        {
            try
            {
                var movie = await _movieRepository.GetById(movieId);
                return movie.Reviews.Count > 0 ? movie.Reviews.Average(r => r.Rating) : 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error calculating movie average rating", ex);
            }
        }

        public async Task AddMovie(MovieDTO movieDto)
        {
            try
            {
                var movie = _mapper.Map<Movie>(movieDto);
                await _movieRepository.Add(movie);
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding movie", ex);
            }
        }

        public async Task<MovieDTO> GetMovieById(Guid movieId)
        {
            try
            {
                var movie = await _movieRepository.GetById(movieId);
                return _mapper.Map<MovieDTO>(movie);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving movie by ID", ex);
            }
        }

        public async Task<IEnumerable<MovieDTO>> GetAllMovies()
        {
            try
            {
                var movies = await _movieRepository.GetAll();
                return _mapper.Map<IEnumerable<MovieDTO>>(movies);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving all movies", ex);
            }
        }

        public async Task UpdateMovie(MovieDTO movieDTO)
        {
            try
            {
                var movie = _mapper.Map<Movie>(movieDTO);
                await _movieRepository.Update(movie);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating movie", ex);
            }
        }

        public async Task DeleteMovie(Guid movieId)
        {
            try
            {
                await _movieRepository.Delete(movieId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting movie", ex);
            }
        }
    }
}
