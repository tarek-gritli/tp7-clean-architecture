using AutoMapper;
using tp7.Application.DTOs;
using tp7.Application.Interfaces;
using tp7.Domain.Entities;
using tp7.Domain.RepositoryInterfaces;

namespace tp7.Application.Services
{
    public class MovieReviewService : IMovieReviewService
    {
        private readonly IGenericRepository<MovieReview> _movieReviewRepository;
        private readonly Mapper _mapper;

        public MovieReviewService(
            IGenericRepository<MovieReview> movieReviewRepository,
            Mapper mapper
        )
        {
            _movieReviewRepository = movieReviewRepository;
            _mapper = mapper;
        }

        public async Task<MovieReviewDTO> AddReview(MovieReviewDTO review)
        {
            var newReview = new MovieReview
            {
                MovieId = review.MovieId,
                CustomerId = review.CustomerId,
                Rating = review.Rating,
                Comment = review.Comment,
            };

            await _movieReviewRepository.Add(newReview);

            return _mapper.Map<MovieReviewDTO>(newReview)
                ?? throw new Exception("Review not created");
        }

        public async Task<MovieReviewDTO> GetMovieReviewById(Guid id)
        {
            var review = await _movieReviewRepository.GetById(id);

            return _mapper.Map<MovieReviewDTO>(review) ?? throw new Exception("Review not found");
        }

        public async Task<MovieReviewDTO> UpdateReview(MovieReviewDTO review)
        {
            var reviewToUpdate = await GetMovieReviewById(review.Id);
            reviewToUpdate.Rating = review.Rating;
            reviewToUpdate.Comment = review.Comment;

            var reviewEntity = _mapper.Map<MovieReview>(reviewToUpdate);
            await _movieReviewRepository.Update(reviewEntity);

            return _mapper.Map<MovieReviewDTO>(reviewEntity)
                ?? throw new Exception("Review not updated");
        }

        public async Task<MovieReviewDTO> DeleteReview(Guid id)
        {
            var review = await GetMovieReviewById(id);

            await _movieReviewRepository.Delete(id);

            return review;
        }
    }
}
