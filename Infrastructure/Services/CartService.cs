using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;

namespace Infrastructure.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            this._cartRepository = cartRepository;
        }
        public async Task<bool> AddCartItemToUser(CartDetailModel item)
        {
            return await this._cartRepository.AddCartToUserId(item);

        }

        public async Task<bool> RemoveCartItemToUser(int userId, int movieId)
        {
            return await this._cartRepository.DeleteCartToUserId(userId, movieId);
        }

        public async Task<bool> ClearCartToUser(int userId)
        {
            return await this._cartRepository.ClearCartToUserId(userId);
        }
    }
}
