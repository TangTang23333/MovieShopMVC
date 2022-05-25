using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace Infrastructure.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _purchaseRepository;

        public PurchaseService(IPurchaseRepository purchaseRepository)
        {
            this._purchaseRepository = purchaseRepository;
        }
        public Task<bool> AddPurchaseToUserId(PurchaseDetailModel entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Purchase> GetPurchaseDetailByMovieId(int userId, int movieId)
        {
            return await this._purchaseRepository.GetPurchaseDetailByMovieId(userId, movieId);
        }
    }
}
