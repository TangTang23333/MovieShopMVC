using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services
{
    public interface IPurchaseService
    {
        Task<bool> AddPurchaseToUserId(PurchaseDetailModel entity);

    }
}
