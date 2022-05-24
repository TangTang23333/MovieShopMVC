using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IFavoriteRepository : IRepository<Favorite>
    {

        Task<List<Favorite>> GetFavoritesByUserId(int userId);
        Task<bool> AddFavoriteToUserId(FavoriteDetailModel entity);

        Task<bool> DeleteFavoriteToUserId(int userId, int movieId);
        Task<bool> ClearFavoriteToUserId(int id);

        Task<bool> IsMovieFavorite(int userId, int movieId);

    }
}
