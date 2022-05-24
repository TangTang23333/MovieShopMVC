using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MovieShopMVC.Controllers
{
    [Authorize] // all action methods require authorizations 
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }
        // GET: UserController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        [HttpGet]
        //[Authorize] // filter they like middleware, piece of code run before action , if not authorized, go to page defined in claims 
        public async Task<ActionResult> Purchased()
        {

            // var data = this.HttpContext.Request.Cookies["MovieShopAuthCookie"];

            // decrypt the cookie , get the claims and check expiration time is reached
            // use useId to get purchased movies
            //var isLoggedIn = this.HttpContext.User.Identity.IsAuthenticated;
            //if (!isLoggedIn)
            //{
            //    return LocalRedirect("~/account/login");
            //}


            // filters using Authorization
            var userId = this.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var purchased = await _userService.GetPurchasesByUserId(Convert.ToInt32(userId));

            return View(purchased);


        }


        [HttpGet]
        //[Authorize] // filter they like middleware, piece of code run before action , if not authorized, go to page defined in claims 
        public async Task<ActionResult> Favorites()
        {

            var userId = this.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var favorites = await _userService.GetFavoritesByUserId(Convert.ToInt32(userId));

            return View(favorites);

        }


        [HttpGet]
        //[Authorize] // filter they like middleware, piece of code run before action , if not authorized, go to page defined in claims 
        public async Task<ActionResult> Cart()
        {

            var userId = this.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var cart = await _userService.GetCartByUserId(Convert.ToInt32(userId));

            return View(cart);

        }



        [HttpGet]
        public async Task<ActionResult> Profile()
        {
            var userId = Convert.ToInt32(this.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var user = await _userService.GetUserProfile(userId);
            return View(user);
        }


        [HttpPost]
        public async Task<ActionResult> Update(UserProfileModel user)
        {

            await _userService.UpdateUser(user);
            return View("Profile", user);
        }




        //[HttpGet]
        ////[Authorize] // filter they like middleware, piece of code run before action , if not authorized, go to page defined in claims 
        //public async Task<ActionResult> Favorite()
        //{

        //    // var data = this.HttpContext.Request.Cookies["MovieShopAuthCookie"];

        //    // decrypt the cookie , get the claims and check expiration time is reached
        //    // use useId to get purchased movies


        //    // filters
        //    var userId = this.HttpContext.User.Claims.FirstOrDefault(x => x.ValueType == ClaimTypes.NameIdentifier)?.Value;
        //    var favorites = await _userService.GetFavoritesByUserId(Convert.ToInt32(userId));

        //    return View(favorites);

        //}


        //[HttpGet]
        ////[Authorize] // filter they like middleware, piece of code run before action , if not authorized, go to page defined in claims 
        //public async Task<ActionResult> Review()
        //{

        //    // var data = this.HttpContext.Request.Cookies["MovieShopAuthCookie"];

        //    // decrypt the cookie , get the claims and check expiration time is reached
        //    // use useId to get purchased movies


        //    // filters
        //    var userId = this.HttpContext.User.Claims.FirstOrDefault(x => x.ValueType == ClaimTypes.NameIdentifier)?.Value;
        //    var reviews = await _userService.GetReviewsByUserId(Convert.ToInt32(userId));

        //    return View(reviews);

        //}

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
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

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
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

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
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
