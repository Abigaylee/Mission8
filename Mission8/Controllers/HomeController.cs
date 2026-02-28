using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering; // Required for SelectList
using Mission8.Models;
using System.Diagnostics;

namespace Mission8.Controllers
{
 
    public class HomeController : Controller
    {
        private ITaskRepository _repo;

        public HomeController(ITaskRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index()
        {
            // This bypasses the search logic and goes straight to the file
            return View();
            //return View(new TaskModel());
        }

        [HttpGet]
        public IActionResult Quadrants()
        {
            // Fetch tasks including categories from the repo
            // .ToList() ensures the view receives a collection instead of null
            var tasks = _repo.Tasks.ToList();
            return View(tasks);
        }

        [HttpGet]
        public IActionResult Tasks()
        {
            // You MUST use 'new SelectList' to map the ID and Name for the dropdown
            ViewBag.Categories = new SelectList(_repo.Categories.ToList(), "CategoryId", "CategoryName");

            return View(new TaskModel());
        }

        [HttpPost]
        public IActionResult SaveTask(TaskModel response)
        {
            if (ModelState.IsValid)
            {
                // Add this logic back in!
                if (response.TaskId == 0)
                {
                    _repo.AddTask(response); // Tell EF this is new
                }
                else
                {
                    _repo.UpdateTask(response); // Tell EF this is an update
                }

                _repo.SaveChanges();
                return RedirectToAction("Quadrants");
            }

            ViewBag.Categories = new SelectList(_repo.Categories.ToList(), "CategoryId", "CategoryName");
            return View("Tasks", response);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Find the specific task to edit
            var task = _repo.Tasks.Single(x => x.TaskId == id);

            ViewBag.Categories = new SelectList(_repo.Categories.ToList(), "CategoryId", "CategoryName");

            // Reuse the "Tasks" view for editing
            return View("Tasks", task);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            // Find the task and remove it via the repository
            var task = _repo.Tasks.Single(x => x.TaskId == id);
            return View(task);
        }

        [HttpPost]
        public IActionResult Delete(TaskModel t)
        {
            _repo.DeleteTask(t);
            _repo.SaveChanges();

            return RedirectToAction("Quadrants");
        }
    }
}