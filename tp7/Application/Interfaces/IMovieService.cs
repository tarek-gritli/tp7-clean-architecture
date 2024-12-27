using tp7.Application.DTOs;

namespace tp7.Application.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDTO>> GetMoviesByGenre(Guid genreId);
    }
}
