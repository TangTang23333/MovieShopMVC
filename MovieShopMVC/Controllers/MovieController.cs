using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class MovieController : Controller
    {



        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }




        // GET: Movie/Detail/5
        public ActionResult Detail(int id)
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

            var movieCards = _movieService.GetTop30GlossingMovies();
            var movieCard = movieCards.Where(x => x.Id == id).SingleOrDefault();
            return View(movieCard);


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

        // GET: MovieController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MovieController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
