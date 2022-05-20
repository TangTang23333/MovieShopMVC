using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services
{
    public interface IUserService


    {

        public Task<List<PurchaseDetailModel>> GetPurchasesByUserId(int userId);
    }
}
