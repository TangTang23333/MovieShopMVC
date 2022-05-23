using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
//using Sitecore.AspNet.RenderingEngine.Binding;




namespace MovieShopMVC.ViewComponents
{
    public class CartItemsNumberViewComponent : ViewComponent
    {


        private readonly IUserService _userService;
        public CartItemsNumberViewComponent(IUserService userService)
        {
            this._userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var userId = this.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var items = await _userService.GetCartByUserId(Convert.ToInt32(userId));

            return View(items.Count);
        }


    }
}
