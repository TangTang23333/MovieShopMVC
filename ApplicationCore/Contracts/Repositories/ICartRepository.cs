using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Repositories
{
    public interface ICartRepository : IRepository<CartItem>
    {
        public Task<List<CartItem>> GetByUser(int userId);


        Task<bool> AddCartToUserId(CartDetailModel entity);
        Task<bool> DeleteCartToUserId(int userId, int movieId);
        Task<bool> ClearCartToUserId(int userId);
    }
}
