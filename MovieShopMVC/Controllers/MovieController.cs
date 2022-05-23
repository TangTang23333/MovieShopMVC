using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MovieShopMVC.Controllers
{
    public class MovieController : Controller
    {



        private readonly IMovieService _movieService;
        private readonly IUserService _userService;

        public MovieController(IMovieService movieService, IUserService userService)
        {
            _movieService = movieService;
            this._userService = userService;
        }




        // GET: Movie/Detail/5
        [HttpGet]
        public async Task<ActionResult> Detail(int id)
        {

            // go to db Movie table and get the movie by id==1
            // connect to sql server and execute SQL Query
            // select * from Movie where id = 2;
            // get the movie object/entity

            // create repositories about data access logic 
            // create services => business logic 
            // controllers action methods -> service method -> repository method -> call DB
            // get the model data from service and send data to view(M)
            // model is the data you want to pass to view 
            // call Onion architecture or N -layer architecture 
            // 

            // Remote DB
            // CPU operation      => calculations, 
            // I/O bound operation  => DB calls, files, images, videos, 

            int userID = 0;
            var userId = this.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId != null)
            {
                userID = Convert.ToInt32(userId);
            }






            var MovieUser = await this._userService.GetMovieDetailByIdByUser(userID, id);




            return View(MovieUser);


        }

        // get movies by genre 
        [HttpGet]
        public async Task<ActionResult> Genre(string genre, int pageNumber = 1, int pageSize = 30)
        {

            var movieOfOnePage = await _movieService.GetMoviesByGenre(genre, pageNumber, pageSize);
            // type: PageResultSet: 


            return View(movieOfOnePage);
        }

        // GET: MovieController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MovieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MovieController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MovieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }




    }
}
