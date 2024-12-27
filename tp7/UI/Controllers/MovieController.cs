using Microsoft.AspNetCore.Mvc;
using tp7.Application.DTOs;
using tp7.Application.Interfaces;

namespace tp7.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // GET: api/movie/genre/{genreId}
        [HttpGet("genre/{genreId}")]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetMoviesByGenre(Guid genreId)
        {
            try
            {
                var movies = await _movieService.GetMoviesByGenre(genreId);
                return Ok(movies);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // GET: /api/movie/avg-rating
        [HttpGet("/avg-rating")]
        public async Task<ActionResult<double>> GetMovieAverageRating(Guid movieId)
        {
            try
            {
                var avgRating = await _movieService.GetMovieAverageRating(movieId);
                return Ok(avgRating);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // GET: api/movie/{movieId}
        [HttpGet("{movieId}")]
        public async Task<ActionResult<MovieDTO>> GetMovieById(Guid movieId)
        {
            try
            {
                var movie = await _movieService.GetMovieById(movieId);
                return Ok(movie);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // GET: api/movie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetAllMovies()
        {
            try
            {
                var movies = await _movieService.GetAllMovies();
                return Ok(movies);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // POST: api/movie
        [HttpPost]
        public async Task<ActionResult<MovieDTO>> AddMovie([FromBody] MovieDTO movieDto)
        {
            try
            {
                await _movieService.AddMovie(movieDto);
                return CreatedAtAction(
                    nameof(GetMovieById),
                    new { movieId = movieDto.Id },
                    movieDto
                );
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // PUT: api/movie/{movieId}
        [HttpPut("{movieId}")]
        public async Task<ActionResult> UpdateMovie(Guid movieId, [FromBody] MovieDTO movieDto)
        {
            try
            {
                if (movieId != movieDto.Id)
                {
                    return BadRequest("Movie ID mismatch.");
                }

                await _movieService.UpdateMovie(movieDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // DELETE: api/movie/{movieId}
        [HttpDelete("{movieId}")]
        public async Task<ActionResult> DeleteMovie(Guid movieId)
        {
            try
            {
                await _movieService.DeleteMovie(movieId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
