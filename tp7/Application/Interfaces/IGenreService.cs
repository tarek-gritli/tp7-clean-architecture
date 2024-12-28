using tp7.Application.DTOs;

namespace tp7.Application.Interfaces
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreDTO>> GetAllGenres();
        Task<GenreDTO> GetGenreById(Guid id);
        Task<GenreDTO> AddGenre(GenreDTO genre);
        Task UpdateGenre(GenreDTO genre);
        Task DeleteGenre(Guid id);
    }
}
