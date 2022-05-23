using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MovieShopMVC.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICartService _cartService;

        public PurchaseController(IUserService userService, ICartService cartService)
        {
            this._userService = userService;
            this._cartService = cartService;
        }
        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> CreatePurchase()
        {
            var userId = this.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var purchases = await this._userService.GetCartByUserId(Convert.ToInt32(userId));
            await this._userService.AddPurchase(purchases);
            await this._cartService.ClearCartToUser(Convert.ToInt32(userId));

            return LocalRedirect("~/user/purchased");


        }
    }
}
