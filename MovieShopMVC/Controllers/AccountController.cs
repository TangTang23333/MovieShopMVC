using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MovieShopMVC.Controllers
{
    public class AccountController : Controller
    {

        private readonly DbContext _context;
        public AccountController(MovieShopDbContext context)
        {
            _context = context;

        }


        // login register
        [HttpGet("login")]
        public IActionResult Login()
        {

            return View();
        }



        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Register(UserRegisterRequestModel user)
        {


            if (user.ConfirmPassword != user.Password)
            {
                return BadRequest("Password does not match!!!");
            }

            // check if email is already registered in db!!!!


            var User = new User
            {
                FirstName = user.Firstname,
                LastName = user.Lastname,
                HashedPassword = user.Password,
                Email = user.Email,
                DateOfBirth = Convert.ToDateTime(user.DateOfBirth),

            };

            this._context.Set<User>().Add(User);
            this._context.SaveChanges();

            return RedirectToAction("Index", "Home");


        }



        // login post 
        [HttpPost("login")]

        public IActionResult Login(UserLoginModel user)
        {

            var userFound = this._context.Set<User>().SingleOrDefault(x => x.Email == user.Email);

            if (userFound == null) return Unauthorized("Invalid username!");


            // salt hash for security, not here for testing purpose 
            // using var hmac = new HMACSHA512(user.PasswordSalt);

            // var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(logindto.Password));

            //for (int i = 0; i < computedHash.Length; i++)
            //{

            //    if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password!");
            //}


            if (userFound.HashedPassword != user.Password)
            {
                return Unauthorized("Incorrect Password, please try again!");
            }

            // tried to pass userInfo to index and upate the navbar but failed
            //UserLoggedIn userInfo = new UserLoggedIn
            //{
            //    FirstName = userFound.FirstName,
            //    LastName = userFound.LastName,
            //    DateOfBirth = userFound.DateOfBirth,
            //    Email = userFound.Email,
            //    Id = userFound.Id


            //};


            //Console.WriteLine(userInfo);
            //TempData.Keep();
            //TempData["user"] = userInfo;

            return RedirectToAction("Index", "Home");

        }







    }
}
