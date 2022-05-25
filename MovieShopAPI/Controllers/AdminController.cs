using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public AdminController(IMovieService movieService)
        {
            this._movieService = movieService;
        }


        [Route("movie")]
        [HttpGet]

        public async Task<IActionResult> CreateNewMovie(MovieCreateRequestModel model)
        {
            var movieCreated = await this._movieService.CreateNewMovie(model);
            return Ok(model);

        }

        [Route("movie")]
        [HttpPut]

        public async Task<IActionResult> UpdateNewMovie(MovieCreateRequestModel model)
        {
            var movie = await this._movieService.CreateNewMovie(model);
            return Ok(movie);

        }

        //[Route("top-purchased-movies")]
        //[HttpGet]
        //public async Task<IActionResult> GetTopPurchasedMovies(DateTime start, DateTime end)
        //{
        //if (end == null && start == null)
        //{
        //    var endDate = DateTime.Today;
        //    var startDate = DateTime.Today.AddDays(-90);
        //}
        //else
        //{
        //    var endDate = start;
        //    var startDate = end;
        //}

        //var movies = this._purchaseService.GetTopPurchasedMovies(startDate, endDate);

        //if (movies == null) { return NotFound("no such movies found!"); }


        //return Ok(movies);







        //}




    }
}
