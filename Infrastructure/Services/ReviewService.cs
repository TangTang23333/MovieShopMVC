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

        public async Task<List<ReviewRequestModel>> GetReviewsByMovieId(int movieId)
        {
            var reviews = await this._reviewRepository.GetMovieReviews(movieId);

            var res = new List<ReviewRequestModel>();
            foreach (var r in reviews)
            {
                res.Add(new ReviewRequestModel
                {
                    MovieId = r.MovieId,
                    UserId = r.UserId,
                    Rating = r.Rating,
                    ReviewText = r.ReviewText
                });
            }

            return res;




        }


        public async Task<List<ReviewRequestModel>> GetReviewsByUserId(int userId)
        {
            var reviews = await this._reviewRepository.GetAllReviewsByUser(userId);

            var res = new List<ReviewRequestModel>();
            foreach (var r in reviews)
            {
                res.Add(new ReviewRequestModel
                {
                    MovieId = r.MovieId,
                    UserId = r.UserId,
                    Rating = r.Rating,
                    ReviewText = r.ReviewText
                });
            }

            return res;
        }

        public async Task<bool> DeleteReview(int userId, int movieId)
        {
            return await this._reviewRepository.DeleteMovieReview(userId, movieId);
        }


    }
}
