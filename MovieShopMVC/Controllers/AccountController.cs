using ApplicationCore.Contracts.Services;
using ApplicationCore.Exceptions;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;

        public AccountController(IAccountService accountService, IUserService userService)
        {
            this._accountService = accountService;
            this._userService = userService;
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


            if (user.ConfirmPassword != user.Password)
            {
                return BadRequest("Password does not match!!!");
            }


            try
            {
                var registerSuccess = await _accountService.RegisterUser(user);
                if (registerSuccess)
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


                if (loginResponse.Id == 0)
                {
                    return View();
                }
            }
            catch (Exception)
            {
                return View();
            }


            return RedirectToAction("Index", "Home");










        }







    }
}
