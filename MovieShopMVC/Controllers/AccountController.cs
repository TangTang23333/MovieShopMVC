using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class AccountController : Controller
    {


        // login register
        public IActionResult Index()
        {
            return View();
        }
    }
}
