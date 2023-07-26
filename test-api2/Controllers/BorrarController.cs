using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace test_api2.Controllers
{
    public class BorrarController : Controller
    {
        // GET: BorrarController
        public ActionResult Index()
        {
            return View();
        }

        // GET: BorrarController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BorrarController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BorrarController/Create
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

        // GET: BorrarController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BorrarController/Edit/5
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

        // GET: BorrarController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BorrarController/Delete/5
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
