using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ReviewRepository : IRepository<Review>, IReviewRepository
    {

        private readonly MovieShopDbContext _context;

        public ReviewRepository(MovieShopDbContext context)
        {
            this._context = context;
        }

        public Task<Review> Add(Review entity)
        {
            throw new NotImplementedException();
        }

        public Task<Review> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Review>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Review> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Review> Update(Review entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Review>> GetMovieReviews(int movieId)
        {
            var reviews = await this._context.Set<Review>()
           .Include(r => r.Movie)
           .Where(r => r.MovieId == movieId).ToListAsync();


            return reviews;
        }
        public async Task<Review> GetMovieReview(int userId, int movieId)
        {


            return await this._context.Set<Review>().FirstOrDefaultAsync(r => r.UserId == userId && r.MovieId == movieId);



        }
        public async Task<bool> AddMovieReview(ReviewRequestModel review)
        {
            try
            {   // make sure it is not update 

                var r = await this._context.Set<Review>().FirstOrDefaultAsync(
                    r => r.UserId == review.UserId && r.MovieId == r.MovieId);

                if (r == null)
                {
                    await this._context.Set<Review>().AddAsync(new Review
                    {
                        UserId = review.UserId,
                        MovieId = review.MovieId,
                        Rating = review.Rating,
                        ReviewText = review.ReviewText

                    });
                    await this._context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    r.Rating = review.Rating;
                    r.ReviewText = review.ReviewText;

                    await this._context.SaveChangesAsync();

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public async Task<bool> UpdateMovieReview(ReviewRequestModel review)
        {
            try
            {
                var r = await this._context.Set<Review>().FirstOrDefaultAsync(r => r.UserId == review.UserId && r.MovieId == review.MovieId);

                if (r != null)
                {
                    r.Rating = review.Rating;
                    r.ReviewText = review.ReviewText;

                    await this._context.SaveChangesAsync();

                }
                else
                {
                    await this._context.Set<Review>().AddAsync(new Review
                    {
                        UserId = review.UserId,
                        MovieId = review.MovieId,
                        Rating = review.Rating,
                        ReviewText = review.ReviewText

                    });
                    await this._context.SaveChangesAsync();


                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> DeleteMovieReview(int userId, int movieId)
        {

            try
            {
                var review = await this._context.Set<Review>().FirstOrDefaultAsync(x => x.UserId == userId && x.MovieId == movieId);
                this._context.Set<Review>().Remove(review);
                await this._context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }



        }
        public async Task<List<Review>> GetAllReviewsByUser(int userId)
        {
            var reviews = await this._context.Set<Review>().Where(x => x.UserId == userId).ToListAsync();
            return reviews;
        }



    }
}
