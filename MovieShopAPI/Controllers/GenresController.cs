using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
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
