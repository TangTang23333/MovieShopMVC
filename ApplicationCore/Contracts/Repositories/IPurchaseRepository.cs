using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IPurchaseRepository : IRepository<Purchase>
    {



        Task<List<Purchase>> GetPurchaseByUserId(int userId);
    }
}
