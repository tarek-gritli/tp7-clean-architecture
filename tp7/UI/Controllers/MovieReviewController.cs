using Microsoft.AspNetCore.Mvc;
using tp7.Application.DTOs;
using tp7.Application.Interfaces;

namespace tp7.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieReviewController : ControllerBase
    {
        private readonly IMovieReviewService _movieReviewService;

        public MovieReviewController(IMovieReviewService movieReviewService)
        {
            _movieReviewService = movieReviewService;
        }

        // GET: api/review/{reviewId}
        [HttpGet("{reviewId}")]
        public async Task<ActionResult<MovieReviewDTO>> GetReviewById(Guid reviewId)
        {
            try
            {
                var review = await _movieReviewService.GetMovieReviewById(reviewId);
                return Ok(review);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // POST: api/review
        [HttpPost]
        public async Task<ActionResult<MovieReviewDTO>> AddReview(
            [FromBody] MovieReviewDTO movieReviewDTO
        )
        {
            try
            {
                await _movieReviewService.AddReview(movieReviewDTO);
                return CreatedAtAction(
                    nameof(GetReviewById),
                    new { reviewId = movieReviewDTO.Id },
                    movieReviewDTO
                );
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // PUT: api/review/{reviewId}
        [HttpPut("{reviewId}")]
        public async Task<ActionResult> UpdateReview(
            Guid reviewId,
            [FromBody] MovieReviewDTO movieReviewDTO
        )
        {
            try
            {
                if (reviewId != movieReviewDTO.Id)
                {
                    return BadRequest("Review ID mismatch.");
                }

                await _movieReviewService.UpdateReview(movieReviewDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // DELETE: api/review/{reviewId}
        [HttpDelete("{reviewId}")]
        public async Task<ActionResult> DeleteReview(Guid reviewId)
        {
            try
            {
                await _movieReviewService.DeleteReview(reviewId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
