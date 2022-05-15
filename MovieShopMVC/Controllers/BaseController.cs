using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace MovieShopMVC.Controllers
{
    public abstract class BaseController : Controller
    {
        public TempDataDictionary TempData { get; set; }
    }
}



