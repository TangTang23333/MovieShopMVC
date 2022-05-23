using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class PurchaseRepository : IRepository<Purchase>, IPurchaseRepository
    {
        private readonly MovieShopDbContext _context;

        public PurchaseRepository(MovieShopDbContext context)
        {
            this._context = context;
        }
        public Task<Purchase> Add(Purchase entity)
        {
            throw new NotImplementedException();
        }

        public Task<Purchase> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Purchase>> GetAll()
        {
            throw new NotImplementedException();
        }



        public Task<Purchase> Update(Purchase entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Purchase>> GetPurchaseByUserId(int userId)
        {


            var purchase = await this._context.Set<Purchase>()
                .Include(p => p.Movie)
                .Where(x => x.UserId == userId).ToListAsync();



            return purchase;
        }


        public async Task<bool> AddPurchaseToUserId(CartDetailModel entity)
        {


            var purchase = new Purchase
            {
                UserId = entity.UserId,
                PurchaseNumber = Guid.NewGuid(),
                TotalPrice = entity.Price,
                PurchaseDateTime = DateTime.Now,
                MovieId = entity.MovieId
            };


            try
            {
                await this._context.Set<Purchase>().AddAsync(purchase);
                await this._context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("item is not purchased successfully!");
                return false;
            }
        }

        public Task<Purchase> GetById(int Id)
        {
            throw new NotImplementedException();
        }




        public async Task<bool> IsMoviePurcahsed(int userId, int movieId)
        {
            var p = await this._context.Set<Purchase>().FirstOrDefaultAsync(p => p.UserId == userId && p.MovieId == movieId);
            return p != null;

        }
    }
}