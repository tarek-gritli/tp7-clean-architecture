using AutoMapper;
using tp7.Application.DTOs;
using tp7.Application.Interfaces;
using tp7.Domain.Entities;
using tp7.Domain.RepositoryInterfaces;

namespace tp7.Application.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenericRepository<Genre> _genreRepository;
        private readonly IMapper _mapper;

        public GenreService(IGenericRepository<Genre> genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GenreDTO>> GetAllGenres()
        {
            var genres = await _genreRepository.GetAll();
            return _mapper.Map<IEnumerable<GenreDTO>>(genres);
        }

        public async Task<GenreDTO> GetGenreById(Guid id)
        {
            try
            {
                var genre = await _genreRepository.GetById(id);
                return _mapper.Map<GenreDTO>(genre);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving genre by id", ex);
            }
        }

        public async Task<GenreDTO> AddGenre(GenreDTO genre)
        {
            try
            {
                var genreEntity = _mapper.Map<Genre>(genre);
                await _genreRepository.Add(genreEntity);
                return genre;
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding genre", ex);
            }
        }

        public async Task UpdateGenre(GenreDTO genre)
        {
            try
            {
                var genreEntity = _mapper.Map<Genre>(genre);
                await _genreRepository.Update(genreEntity);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating genre", ex);
            }
        }

        public async Task DeleteGenre(Guid id)
        {
            try
            {
                await _genreRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting genre", ex);
            }
        }
    }
}
