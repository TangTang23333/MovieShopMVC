using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services
{
    public interface IReviewService
    {

        public Task<bool> AddReview(ReviewRequestModel entity);
        public Task<bool> UpdateReview(ReviewRequestModel entity);
    }

}
