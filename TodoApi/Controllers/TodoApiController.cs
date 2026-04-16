using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoLibrary.Models;
using TodoLibrary.Repos;

namespace TodoApi.Controllers
{
    public class TodoApiController : Controller
    {
        private readonly ITodoRepo _repo;

        public TodoApiController(ITodoRepo repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        // GET: TodoApiController
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var tasks = await _repo.GetAllTasksAsync();
            return View(tasks);
        }

        // GET: TodoApiController/Details/5
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var task = (await _repo.GetAllTasksAsync()).FirstOrDefault(t => t.TaskNo == id);
            if (task == null) return NotFound();
            return View(task);
        }

        // GET: TodoApiController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TodoApiController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaskNo,Title,Description,StartDate,DueDate,Priority,Status")] Todo task)
        {
            if (!ModelState.IsValid) return View(task);

            try
            {
                await _repo.AddTaskAsync(task);
                return RedirectToAction(nameof(Index));
            }
            catch (TodoException tex)
            {
                ModelState.AddModelError(string.Empty, tex.Message);
                return View(task);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "An unexpected error occurred while creating the task.");
                return View(task);
            }
        }

        // GET: TodoApiController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var task = (await _repo.GetAllTasksAsync()).FirstOrDefault(t => t.TaskNo == id);
            if (task == null) return NotFound();
            return View(task);
        }

        // POST: TodoApiController/Edit/5
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaskNo,Title,Description,StartDate,DueDate,Priority,Status")] Todo task)
        {
            if (id != task.TaskNo) return BadRequest();

            if (!ModelState.IsValid) return View(task);

            try
            {
                await _repo.UpdateTaskAsync(task);
                return RedirectToAction(nameof(Index));
            }
            catch (TodoException tex)
            {
                ModelState.AddModelError(string.Empty, tex.Message);
                return View(task);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "An unexpected error occurred while updating the task.");
                return View(task);
            }
        }

        // GET: TodoApiController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var task = (await _repo.GetAllTasksAsync()).FirstOrDefault(t => t.TaskNo == id);
            if (task == null) return NotFound();
            return View(task);
        }

        // POST: TodoApiController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var task = (await _repo.GetAllTasksAsync()).FirstOrDefault(t => t.TaskNo == id);
            if (task == null) return NotFound();

            try
            {
                await _repo.DeleteTaskAsync(task);
                return RedirectToAction(nameof(Index));
            }
            catch (TodoException tex)
            {
                ModelState.AddModelError(string.Empty, tex.Message);
                return View(task);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "An unexpected error occurred while deleting the task.");
                return View(task);
            }
        }
    }
}
