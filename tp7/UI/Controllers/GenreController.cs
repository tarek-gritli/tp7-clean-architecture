using Microsoft.AspNetCore.Mvc;
using tp7.Application.DTOs;
using tp7.Application.Interfaces;

namespace tp7.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        // GET: api/genre
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreDTO>>> GetAllGenres()
        {
            try
            {
                var genres = await _genreService.GetAllGenres();
                return Ok(genres);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // GET: api/genre/{genreId}
        [HttpGet("{genreId}")]
        public async Task<ActionResult<GenreDTO>> GetGenreById(Guid genreId)
        {
            try
            {
                var genre = await _genreService.GetGenreById(genreId);
                return Ok(genre);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // POST: api/genre
        [HttpPost]
        public async Task<ActionResult<GenreDTO>> AddGenre([FromBody] GenreDTO genreDTO)
        {
            try
            {
                await _genreService.AddGenre(genreDTO);
                return CreatedAtAction(
                    nameof(GetGenreById),
                    new { genreId = genreDTO.Id },
                    genreDTO
                );
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // PUT: api/genre/{genreId}
        [HttpPut("{genreId}")]
        public async Task<ActionResult> UpdateGenre(Guid genreId, [FromBody] GenreDTO genreDTO)
        {
            try
            {
                if (genreId != genreDTO.Id)
                {
                    return BadRequest("Genre ID mismatch.");
                }

                await _genreService.UpdateGenre(genreDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // DELETE: api/genre/{genreId}
        [HttpDelete("{genreId}")]
        public async Task<ActionResult> DeleteGenre(Guid genreId)
        {
            try
            {
                await _genreService.DeleteGenre(genreId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
