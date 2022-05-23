using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Services;

namespace MovieShopMVC.Controllers
{
    [Authorize]
    public class FavoriteController : Controller

    {
        private readonly IFavoriteService _favoriteService;
        private readonly ICurrentUser _currentUser;

        public FavoriteController(IFavoriteService favoriteService, ICurrentUser currentUser)
        {
            this._favoriteService = favoriteService;
            this._currentUser = currentUser;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> AddFavorite(int id)
        {
            string currentURL = Request.Headers["Referer"].ToString();

            var entity = new FavoriteDetailModel
            {
                UserId = (int)this._currentUser.UserId,
                MovieId = id
            };

            try
            {
                await _favoriteService.AddFavoriteToUserId(entity);
                return Redirect(currentURL);
            }
            catch (Exception ex)
            {
                throw new Exception("add favorite not successful");
            }



        }

        public async Task<IActionResult> RemoveFavorite(int id)
        {
            string currentURL = Request.Headers["Referer"].ToString();



            try
            {

                await _favoriteService.RemoveFavoriteToUserId(id);
                return Redirect(currentURL);
            }
            catch (Exception ex)
            {
                throw new Exception("REMOVE favorite not successful");
            }
        }

        public async Task<IActionResult> ClearFavorite(int userId)
        {
            string currentURL = Request.Headers["Referer"].ToString();



            try
            {
                await _favoriteService.ClearFavoriteToUserId(userId);
                return Redirect(currentURL);
            }
            catch (Exception ex)
            {
                throw new Exception("CLEAR favorite not successful");
            }
        }
    }
}
