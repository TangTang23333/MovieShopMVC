using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services
{
    public interface ICartService
    {

        public Task<bool> AddCartItemToUser(CartDetailModel item);
        public Task<bool> RemoveCartItemToUser(int userId, int movieId);
        public Task<bool> ClearCartToUser(int userId);
    }
}
