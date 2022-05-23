using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;

namespace Infrastructure.Services
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IFavoriteRepository _favoriteRepository;

        public FavoriteService(IFavoriteRepository favoriteRepository)
        {
            this._favoriteRepository = favoriteRepository;
        }
        public async Task<bool> AddFavoriteToUserId(FavoriteDetailModel entity)
        {
            return await this._favoriteRepository.AddFavoriteToUserId(entity);

        }

        public async Task<bool> ClearFavoriteToUserId(int userId)
        {
            return await this._favoriteRepository.ClearFavoriteToUserId(userId);

        }

        public async Task<bool> RemoveFavoriteToUserId(int id)

        {
            return await this._favoriteRepository.DeleteFavoriteToUserId(id);
        }

        public async Task<bool> RemoveFavoriteToUserId(int userId, int movieId)

        {
            return await this._favoriteRepository.DeleteFavoriteToUserId(userId, movieId);
        }
    }
}
