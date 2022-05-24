using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            this._movieService = movieService;
        }




        [Route("")]
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {

            var movies = this._movieService.GetMoviesByReleaseDate();
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


        //[Route("{id}")]
        //[HttpGet]
        //public async Task<IActionResult> Details(int id);


        //[Route("{id}")]
        //[HttpGet]
        //public async Task<IActionResult> Details(int id);



        //[Route("{id}")]
        //[HttpGet]
        //public async Task<IActionResult> Details(int id);
    }
}
