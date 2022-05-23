using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class FavoriteRepository : IRepository<Favorite>, IFavoriteRepository
    {
        private readonly MovieShopDbContext _context;

        public FavoriteRepository(MovieShopDbContext context)
        {
            this._context = context;
        }




        public Task<List<Favorite>> GetAll()
        {
            throw new NotImplementedException();
        }



        public async Task<Favorite> Update(Favorite entity)
        {


            throw new NotImplementedException();

        }

        public async Task<List<Favorite>> GetFavoritesByUserId(int userId)
        {


            var favorite = await this._context.Set<Favorite>()
                .Include(f => f.Movie)
                .Where(x => x.UserId == userId).ToListAsync();



            return favorite;
        }



        public async Task<bool> AddFavoriteToUserId(FavoriteDetailModel favoriteDetailModel)
        {
            var entity = new Favorite
            {
                Id = favoriteDetailModel.Id,
                UserId = favoriteDetailModel.UserId,
                MovieId = favoriteDetailModel.MovieId
            };

            try
            {
                await this._context.Set<Favorite>().AddAsync(entity);
                await this._context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }





        public async Task<bool> DeleteFavoriteToUserId(int id)
        {


            try
            {
                var f = await this._context.Set<Favorite>().FirstOrDefaultAsync(f => f.Id == id);
                this._context.Set<Favorite>().Remove(f);
                await this._context.SaveChangesAsync();
                return true;
            }
            catch
            {

                return false;
            }
        }


        public async Task<bool> DeleteFavoriteToUserId(int userId, int movieId)
        {


            try
            {
                var f = await this._context.Set<Favorite>().FirstOrDefaultAsync(f => f.UserId == userId && f.MovieId == movieId);
                this._context.Set<Favorite>().Remove(f);
                await this._context.SaveChangesAsync();
                return true;
            }
            catch
            {

                return false;
            }
        }

        public async Task<bool> ClearFavoriteToUserId(int userId)
        {
            try
            {
                var allFavorites = this._context.Set<Favorite>().Where(f => f.Id == userId);
                this._context.Set<Favorite>().RemoveRange(allFavorites);
                await this._context.SaveChangesAsync();
                return true;
            }
            catch
            {

                return false;
            }
        }

        public Task<Favorite> Add(Favorite entity)
        {
            throw new NotImplementedException();
        }

        public Task<Favorite> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Favorite> GetById(int Id)
        {
            throw new NotImplementedException();
        }



        public async Task<bool> IsMovieFavorite(int userId, int movieId)
        {

            var f = await this._context.Set<Favorite>().FirstOrDefaultAsync(f => f.UserId == userId && f.MovieId == movieId);

            return f != null;
        }
    }
}

