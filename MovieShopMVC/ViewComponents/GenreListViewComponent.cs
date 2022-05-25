using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
//using Sitecore.AspNet.RenderingEngine.Binding;




namespace MovieShopMVC.ViewComponents
{
    public class GenreListViewComponent : ViewComponent
    {


        private readonly IGenreService _genreService;
        public GenreListViewComponent(IGenreService genreService)
        {
            this._genreService = genreService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {


            var genres = await this._genreService.GetGenreList();

            return View(genres);
        }


    }
}
