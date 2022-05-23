using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;

namespace Infrastructure.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            this._reviewRepository = reviewRepository;
        }
        public async Task<bool> AddReview(ReviewRequestModel entity)
        {
            return await this._reviewRepository.AddMovieReview(entity);
        }


        public async Task<bool> UpdateReview(ReviewRequestModel entity)
        {
            return await this._reviewRepository.UpdateMovieReview(entity);
        }
    }
}
