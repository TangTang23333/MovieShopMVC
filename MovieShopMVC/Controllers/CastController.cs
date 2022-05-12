using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class CastController : Controller
    {
        // GET: CastController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CastController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CastController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CastController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CastController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CastController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CastController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CastController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
