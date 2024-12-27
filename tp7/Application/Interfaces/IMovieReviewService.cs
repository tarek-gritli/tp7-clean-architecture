using tp7.Application.DTOs;

namespace tp7.Application.Interfaces
{
    public interface IMovieReviewService
    {
        Task<MovieReviewDTO> AddReview(MovieReviewDTO review);
        Task<MovieReviewDTO> GetMovieReviewById(Guid id);
        Task<MovieReviewDTO> UpdateReview(MovieReviewDTO review);
        Task<MovieReviewDTO> DeleteReview(Guid id);
    }
}
