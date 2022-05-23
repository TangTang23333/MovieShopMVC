﻿using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services
{
    public interface IUserService


    {

        public Task<List<PurchaseDetailModel>> GetPurchasesByUserId(int userId);
        public Task<List<FavoriteDetailModel>> GetFavoritesByUserId(int userId);

        public Task<List<CartDetailModel>> GetCartByUserId(int userId);

        public Task<MovieDetailByUserModel> GetMovieDetailByIdByUser(int userId, int movieId);

        public Task<bool> IsMoviePurchased(int userId, int movieId);


        public Task<bool> IsMovieFavorite(int userId, int id);
        public Task<bool> AddPurchase(List<CartDetailModel> purchases);
    }
}
