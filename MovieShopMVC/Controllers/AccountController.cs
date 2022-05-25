using ApplicationCore.Contracts.Services;
using ApplicationCore.Exceptions;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MovieShopMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            this._accountService = accountService;

        }


        // login register
        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }



        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }



        // to post infomation
        [HttpPost]

        public async Task<IActionResult> Register(UserRegisterRequestModel user)
        {

            // modelstate is member of controller , check the incoming data model is valid or not 
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (user.ConfirmPassword != user.Password)
            {
                return BadRequest("Password does not match!!!");
            }


            try
            {
                var registerSuccess = await _accountService.RegisterUser(user);
                if (registerSuccess != null)
                {

                    return RedirectToAction("Login");
                }
                else
                {
                    return BadRequest("Some problem occured, please try again later.");
                }
            }
            catch (ConflictException)
            {
                throw;

                //loggin exceptions
            }




        }



        // login post 
        [HttpPost]

        public async Task<IActionResult> Login(UserLoginModel user)
        {



            try
            {
                var loginResponse = await _accountService.LoginUser(user);

                // can be self defined
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Email, loginResponse.Email),
                    new Claim(ClaimTypes.GivenName, loginResponse.FirstName),
                    new Claim(ClaimTypes.Surname, loginResponse.LastName),
                    new Claim(ClaimTypes.NameIdentifier, loginResponse.Id.ToString()),
                    new Claim(ClaimTypes.DateOfBirth, Convert.ToDateTime(loginResponse.DateOfBirth).Date.ToString("d")),

                    new Claim("Language", "English")


                };

                //identity
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                //create cookie with above claims

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));


                // asp .net how long the cookie is gonna be valid
                // name of the cookie you want to create and stored in browser


                if (loginResponse != null)
                {
                    return LocalRedirect("~/");
                }


            }
            catch (Exception)
            {
                return View();
            }


            return View();



        }




        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return LocalRedirect("~/");
        }


    }
}
