using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class CastController : Controller
    {
        private readonly ICastService _castService;

        public CastController(ICastService castService)
        {
            this._castService = castService;
        }


        // GET: CastController/Detail/5
        public async Task<ActionResult> Detail(int id)
        {

            var cast = await this._castService.GetById(id);
            return View(cast);
        }

        // GET: CastController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CastController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]


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
