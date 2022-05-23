using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Services;

namespace MovieShopMVC.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;
        private readonly ICurrentUser _currentUser;
        public ReviewController(IReviewService reviewService, ICurrentUser currentUser)
        {
            _currentUser = currentUser;


            _reviewService = reviewService;

        }



        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddReview(string rating, string reviewText, int id)
        {

            string currentURL = Request.Headers["Referer"].ToString();

            var review = new ReviewRequestModel
            {
                UserId = (int)this._currentUser.UserId,
                MovieId = id,
                Rating = Convert.ToInt32(rating),
                ReviewText = reviewText

            };

            try
            {
                await _reviewService.AddReview(review);
                return Redirect(currentURL);
            }
            catch (Exception ex)
            {
                throw new Exception("add favorite not successful");
            }


        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UpdateReview(string rating, string reviewText, int id)
        {

            string currentURL = Request.Headers["Referer"].ToString();

            var review = new ReviewRequestModel
            {
                UserId = (int)this._currentUser.UserId,
                MovieId = id,
                Rating = Convert.ToInt32(rating),
                ReviewText = reviewText

            };

            try
            {
                await _reviewService.UpdateReview(review);
                return Redirect(currentURL);
            }
            catch (Exception ex)
            {
                throw new Exception("Upate favorite not successful");
            }


        }






    }
}
