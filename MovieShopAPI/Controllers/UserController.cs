using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MovieShopAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IFavoriteService _favoriteService;
        private readonly IReviewService _reviewService;
        private readonly IPurchaseService _purchaseService;

        public UserController(IUserService userService, IFavoriteService favoriteService, IReviewService reviewService,
            IPurchaseService purchaseService)
        {
            this._userService = userService;
            this._favoriteService = favoriteService;
            this._reviewService = reviewService;
            this._purchaseService = purchaseService;
        }
        [Route("Details")]
        [HttpGet]

        public async Task<IActionResult> GetUserProfile()
        {

            var userId = Convert.ToInt32(this.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var user = await this._userService.GetUserProfile(userId);

            if (user == null)
            {
                return NotFound(" no such user found!");
            }

            return Ok(user);
        }

        [Route("Purchase-movie")]
        [HttpPost]

        public async Task<IActionResult> CreatePurchaseAPI(PurchaseRequestModel purchase)
        {


            var response = await this._userService.CreatePurchaseAPI(purchase);
            if (response == null)
            {
                return NotFound("Purchase is not successful!");
            }

            return Ok(response);

        }


        [Route("Favortie")]
        [HttpPost]
        public async Task<IActionResult> CreateFavoriteAPI(int movieId)
        {
            var userId = Convert.ToInt32(this.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var favorite = await this._favoriteService.CreateFavoriteAPI(userId, movieId);

            if (favorite == null)
            {
                return BadRequest("add favorite not successful!");
            }

            return Ok(favorite);
        }


        [Route("un-Favortie")]
        [HttpPost]
        public async Task<IActionResult> DeleteFavoriteAPI(int movieId)
        {
            var userId = Convert.ToInt32(this.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var favorite = await this._favoriteService.RemoveFavoriteToUserId(userId, movieId);
            if (favorite)
            {
                return Ok(favorite);
            }
            return BadRequest("Delete favorite not success!");

        }

        [Route("check-movie-favorite/{movieId}")]
        [HttpGet]
        public async Task<IActionResult> IsFavoriteAPI(int movieId)
        {
            var userId = Convert.ToInt32(this.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var isMovieFavorite = await this._userService.IsMovieFavorite(userId, movieId);
            if (isMovieFavorite != null) { return Ok(isMovieFavorite); }
            return BadRequest("Check favorite failed!");
        }


        [Route("add-review")]
        [HttpPost]
        public async Task<IActionResult> CreateReviewAPI(ReviewRequestModel model)
        {
            var res = await this._reviewService.AddReview(model);


            return Ok(res);
        }

        [Route("edit-review")]
        [HttpPut]
        public async Task<IActionResult> EditReviewAPI(ReviewRequestModel model)
        {
            var res = await this._reviewService.UpdateReview(model);

            return Ok(res);
        }


        [Route("delete-review/{moiveId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteReviewAPI(int movieId)
        {
            var userId = Convert.ToInt32(this.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            return Ok(await this._reviewService.DeleteReview(userId, movieId));

        }


        [Route("purchases")]
        [HttpGet]
        public async Task<IActionResult> GetPurchasesAPI()
        {
            var userId = Convert.ToInt32(this.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var purchases = await this._userService.GetPurchasesByUserId(userId);
            return Ok(purchases);
        }


        [Route("Purchase-details/{movieId}")]
        [HttpGet]
        public async Task<IActionResult> GetPurchaseDetailAPI(int movieId)
        {
            var userId = Convert.ToInt32(this.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var purchase = await this._purchaseService.GetPurchaseDetailByMovieId(userId, movieId);
            if (purchase != null)
            { return Ok(purchase); }
            return BadRequest("no such purchase record exists!");
        }




        [Route("check-movie-purchased/{movieId}")]
        [HttpGet]
        public async Task<IActionResult> IsPurchasedAPI(int movieId)
        {
            var userId = Convert.ToInt32(this.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            return Ok(await this._userService.IsMoviePurchased(userId, movieId));


        }


        [Route("favorites")]
        [HttpGet]
        public async Task<IActionResult> GetAllFavoritesAPI()
        {
            var userId = Convert.ToInt32(this.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            return Ok(await this._userService.GetFavoritesByUserId(userId));
        }


        [Route("movie-reviews")]
        [HttpGet]
        public async Task<IActionResult> GetAllReviewsByUserIdAPI()
        {
            var userId = Convert.ToInt32(this.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            return Ok(await this._reviewService.GetReviewsByUserId(userId));
        }




    }
}
