using tp7.Application.DTOs;

namespace tp7.Application.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDTO>> GetMoviesByGenre(Guid genreId);

        Task<double> GetMovieAverageRating(Guid movieId);

        Task AddMovie(MovieDTO movieDto);

        Task<MovieDTO> GetMovieById(Guid movieId);

        Task<IEnumerable<MovieDTO>> GetAllMovies();

        Task UpdateMovie(MovieDTO movieDTO);

        Task DeleteMovie(Guid movieId);
    }
}
