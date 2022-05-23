using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IReviewRepository : IRepository<Review>
    {
        public Task<Review> GetMovieReview(int userId, int movieId);
        public Task<List<Review>> GetMovieReviews(int movieId);
        public Task<bool> AddMovieReview(ReviewRequestModel review);
        public Task<bool> UpdateMovieReview(ReviewRequestModel review);
        public Task<bool> DeleteMovieReview(int userId, int movieId);


        public Task<List<Review>> GetAllReviewsByUser(int userId);


    }
}
