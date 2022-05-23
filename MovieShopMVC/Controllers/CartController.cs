using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Services;

namespace MovieShopMVC.Controllers
{
    [Authorize]
    public class CartController : Controller

    {
        private readonly ICartService _cartService;
        private readonly ICurrentUser _currentUser;
        private readonly IFavoriteService _favoriteService;

        public CartController(ICartService cartService, ICurrentUser currentUser, IFavoriteService favoriteService)
        {
            this._cartService = cartService;
            this._currentUser = currentUser;
            this._favoriteService = favoriteService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            return View();

        }


        public async Task<IActionResult> Add(int id)
        {
            string currentURL = Request.Headers["Referer"].ToString();

            // if request from favorites, then delete favorites
            bool isFavorite = currentURL.Contains("favorites");
            var userId = (int)this._currentUser.UserId;

            var entity = new CartDetailModel
            {
                UserId = userId,
                MovieId = id,


            };

            try
            {
                await _cartService.AddCartItemToUser(entity);
                if (isFavorite)
                {
                    await _favoriteService.RemoveFavoriteToUserId(userId, id);
                }
                return Redirect(currentURL);
            }
            catch (Exception ex)
            {
                throw new Exception("add cart not successful");
            }



        }



        public async Task<IActionResult> Remove(int movieId, int userId)
        {
            string currentURL = Request.Headers["Referer"].ToString();



            try
            {
                await _cartService.RemoveCartItemToUser(userId, movieId);
                return Redirect(currentURL);
            }
            catch (Exception ex)
            {
                throw new Exception("remove cart not successful");
            }
        }


        public async Task<IActionResult> Clear(int id)
        {
            string currentURL = Request.Headers["Referer"].ToString();


            try
            {
                await _cartService.ClearCartToUser(id);
                return Redirect(currentURL);
            }
            catch (Exception ex)
            {
                throw new Exception("add cart not successful");
            }
        }


    }
}

