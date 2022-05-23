using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IPurchaseRepository : IRepository<Purchase>
    {



        Task<List<Purchase>> GetPurchaseByUserId(int userId);
        Task<bool> AddPurchaseToUserId(CartDetailModel entity);

        Task<bool> IsMoviePurcahsed(int userId, int movieId);


    }
}
