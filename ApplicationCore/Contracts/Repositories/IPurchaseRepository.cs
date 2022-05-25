using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IPurchaseRepository : IRepository<Purchase>
    {


        Task<Purchase> CreatePurchaseAPI(PurchaseRequestModel entity);
        Task<List<Purchase>> GetPurchaseByUserId(int userId);
        Task<bool> AddPurchaseToUserId(CartDetailModel entity);
        Task<Purchase> GetPurchaseDetailByMovieId(int userId, int movieId);
        Task<bool> IsMoviePurcahsed(int userId, int movieId);


    }
}
