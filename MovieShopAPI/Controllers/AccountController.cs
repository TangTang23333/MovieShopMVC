using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopAPI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            this._accountService = accountService;
        }

        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> RegisterUser(UserRegisterRequestModel user)
        {
            var userResponse = await this._accountService.RegisterUser(user);

            if (user == null)
            {
                return NotFound("register is not successful!");
            }

            return Ok(userResponse);


        }

        [Route("check-email")]
        [HttpGet]
        public async Task<IActionResult> CheckEmail(string email)
        {
            var user = await this._accountService.CheckEmail(email);

            if (user == null)
            {
                return Ok("not exist in database");
            }

            return Ok(user);
        }

        [Route("login")]
        [HttpGet]
        public async Task<IActionResult> UserLogin(UserLoginModel user)
        {
            var userResponse = await this._accountService.LoginUser(user);

            if (userResponse == null)
            {
                return NotFound("Please double check your email and password!");
            }

            return Ok(userResponse);

        }


    }
}
