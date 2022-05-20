using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
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

        Task<Purchase> IRepository<Purchase>.GetById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
