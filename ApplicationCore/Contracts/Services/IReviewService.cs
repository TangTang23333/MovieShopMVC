using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services
{
    public interface IReviewService
    {

        public Task<bool> AddReview(ReviewRequestModel entity);
        public Task<bool> UpdateReview(ReviewRequestModel entity);
        public Task<bool> DeleteReview(int userId, int movieId);
        public Task<List<ReviewRequestModel>> GetReviewsByMovieId(int movieId);
        public Task<List<ReviewRequestModel>> GetReviewsByUserId(int userId);
    }

}
