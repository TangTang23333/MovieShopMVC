using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services
{
    public interface IPurchaseService
    {
        Task<bool> AddPurchaseToUserId(PurchaseDetailModel entity);
        Task<Purchase> GetPurchaseDetailByMovieId(int userId, int movieId);
    }
}
