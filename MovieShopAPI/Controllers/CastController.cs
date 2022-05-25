using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopAPI.Controllers
{
    public class CastController : Controller
    {
        private readonly ICastService _castService;

        public CastController(ICastService castService)
        {
            this._castService = castService;
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetCastDetailsByCastId(int id)
        {
            var cast = await this._castService.GetById(id);

            if (cast == null)
            {
                return NotFound("no cast is found!");
            }

            return Ok(cast);
        }


    }
}
