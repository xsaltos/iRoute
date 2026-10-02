using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace iRoute.Controllers
{
    public class CommerceController : Controller
    {
        // GET: CommerceController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CommerceController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CommerceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CommerceController/Create
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

        // GET: CommerceController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CommerceController/Edit/5
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

        // GET: CommerceController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CommerceController/Delete/5
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
