using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
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
        [HttpPost]
        public async Task<IActionResult> UserLogin(UserLoginModel user)
        {
            var userResponse = await this._accountService.LoginUser(user);
            // return a token...
            // JWT Json Web Token
            // iOS, Android app oe Web APP (Angular or React)
            // once it is created, it is stored in the ios => device,
            // browser => localstorage
            // android => in the device 
            // show all the movies user purchased
            // send the token in the http header 
            // api will validate the token and then send the response back 
            // authorize filter 
            // 

            var jwtToken = GenerateJWTToken(userResponse);
            return Ok(new { Token = jwtToken });

            //if (userResponse == null)
            //{
            //    return NotFound("Please double check your email and password!");
            //}

            //return Ok(userResponse);

        }
        private string GenerateJWTToken(UserLoginResponseModel user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("Language", "English")


            };

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MyTopSecretKeysdfsfaergkjakueqhjxndckjiut3478yshkasnkfahsd"));

            // specify the algorithm to be used 

            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            // how long the token is valid , expire in 2 hours 
            var tokenExpiration = DateTime.UtcNow.AddHours(2);

            var tokenHandler = new JwtSecurityTokenHandler();

            // create an object for above details for the token 
            var tokenDetails = new SecurityTokenDescriptor
            {
                Subject = identityClaims,
                Expires = tokenExpiration,
                SigningCredentials = credentials,
                Issuer = "TT MovieShop",
                Audience = "MovieShop user"
            };

            var encodedJWT = tokenHandler.CreateToken(tokenDetails);
            // token can be easily decoded, never save essential info in token, just for session use.
            return tokenHandler.WriteToken(encodedJWT);

        }




    }
}
