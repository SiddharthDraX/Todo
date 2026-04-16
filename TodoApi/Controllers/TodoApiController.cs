using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Controllers
{
    public class TodoApiController : Controller
    {
        // GET: TodoApiController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TodoApiController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TodoApiController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TodoApiController/Create
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

        // GET: TodoApiController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TodoApiController/Edit/5
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

        // GET: TodoApiController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TodoApiController/Delete/5
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
