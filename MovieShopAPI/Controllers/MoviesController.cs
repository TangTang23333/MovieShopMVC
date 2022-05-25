using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IReviewService _reviewService;

        public MoviesController(IMovieService movieService, IReviewService reviewService)
        {
            this._movieService = movieService;
            this._reviewService = reviewService;
        }



        //api/movies/ default page number = 1 , pagesize = 30
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var movies = await this._movieService.GetMoviesByReleaseDate();

            if (movies == null)
            {
                return NotFound("Movies not found!");
            }
            return Ok(movies);
        }

        // api/movies/top-grossing
        [Route("top-grossing")]
        [HttpGet]
        public async Task<IActionResult> TopGrossing()
        {
            var movies = await this._movieService.GetTop30GlossingMovies();

            if (movies == null || !movies.Any())
            {
                return NotFound();
            }


            return Ok(movies);
        }


        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var movie = await this._movieService.GetMovieDetailsById(id);
            if (movie == null)
            {
                return NotFound(new { ErrorMessage = "no movie found" });
            }
            return Ok(movie);
        }


        [Route("top-rated")]
        [HttpGet]
        public async Task<IActionResult> TopRated()
        {
            var movies = await this._movieService.GetTopRated30();

            if (movies == null)
            {
                return NotFound("no such movies found!");
            }

            return Ok(movies);

        }


        [Route("genre/{genreId}")]
        [HttpGet]
        public async Task<IActionResult> GetByGenreId(int genreId)
        {
            var movies = await this._movieService.GetMoviesByGenreId(genreId);

            if (movies == null)
            {
                return NotFound("No such movies found!");
            }

            return Ok(movies);
        }



        [Route("{id}/reviews")]
        [HttpGet]
        public async Task<IActionResult> GetReviewsByMovieId(int id)
        {
            var reviews = await this._reviewService.GetReviewsByMovieId(id);
            if (reviews == null)
            {
                return NotFound("no reviews are found!");
            }

            return Ok(reviews);


        }
    }
}
