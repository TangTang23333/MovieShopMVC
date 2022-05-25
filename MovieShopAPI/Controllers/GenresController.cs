using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopAPI.Controllers
{
    public class GenresController : Controller
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            this._genreService = genreService;
        }
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetAllGenres()
        {
            var genres = await this._genreService.GetGenreList();

            if (genres == null)
            {
                return NotFound("no genres are found");
            }
            return Ok(genres);
        }


    }
}
