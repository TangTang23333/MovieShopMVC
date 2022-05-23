using System.Security.Claims;

namespace MovieShopMVC.Services
{
    public class CurrentUser : ICurrentUser // can be used anywhere in our app
    {  // access httpcontext inside a class which is not a controller 
        private readonly IHttpContextAccessor _httpContextAccessor;

        // inject HttpContext class inside this regular class

        public CurrentUser(IHttpContextAccessor httpContextAccessor)
        {

            this._httpContextAccessor = httpContextAccessor;
        }
        public int? UserId => Convert.ToInt32(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

        public bool IsAdmin => throw new NotImplementedException();

        public bool IsAuthenticated => _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;

        public string Email => _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value;

        public string Firstname => _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.GivenName).Value;

        public string Lastname => _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Surname).Value;

        //??public int cartItemsNumber => _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.).Value;

        public List<string> Roles => throw new NotImplementedException();

    }
}
