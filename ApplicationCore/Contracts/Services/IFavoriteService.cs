using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services
{
    public interface IFavoriteService
    {

        Task<bool> AddFavoriteToUserId(FavoriteDetailModel entity);

        Task<bool> RemoveFavoriteToUserId(int userId, int movieId);
        Task<bool> ClearFavoriteToUserId(int userId);



    }
}
