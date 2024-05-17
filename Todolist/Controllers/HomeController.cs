using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
using Todo.Service;
using TodoList.Domain;
using Todolist.Models;
using TodoList.Domain.Interface;


namespace Todolist.Controllers
{
    public class HomeController(ITodoService service) : Controller
    {
        
        public IActionResult Index(string id)
        {
            var temp = service.GetAll();
            //var filters = new Filters(id);
            //ViewBag.Filters = filters;
            ViewBag.Categories = Enum.GetValues(typeof(Category));
            ViewBag.Statuses =  Enum.GetValues(typeof(Status));
            //ViewBag.DueFilters = Filters.DueFilterValues;

            //IQueryable<ToDo> query = service.ToDoS
            //    .Include(t => t.Category)
            //    .Include(t => t.Status);

            //if (filters.HasCategory)
            //{
            //    query = query.Where(t => t.CategoryId == filters.CategoryId);
            //}

            //if (filters.HasStatus)
            //{
            //    query = query.Where(t => t.StatusId == filters.StatusId);
            //}

            //if (filters.HasDue)
            //{
            //    var today = DateTime.Today;
            //    if (filters.IsPast)
            //    {
            //        query = query.Where(t => t.DueDate < today);
            //    }
            //    else if (filters.IsFuture)
            //    {
            //        query = query.Where(t => t.DueDate > today);

            //    }
            //    else if (filters.IsToday)
            //    {
            //        query = query.Where(t => t.DueDate == today);
            //    }
            //}
            //var tasks = query.OrderBy(t => t.DueDate).ToList();

            //return View(tasks);

            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Categories = Enum.GetValues(typeof(Category));
            ViewBag.Statuses = Enum.GetValues( typeof(Status));
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddTodoModel model)
        {
            if (ModelState.IsValid)
            {
                service.Add(model);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Categories = Enum.GetValues(typeof(Category));
                ViewBag.Statuses = Enum.GetValues(typeof(Status));
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult Filter(string[] filter)
        {
            string id = string.Join("-", filter);
            return RedirectToAction("Index", new { ID = id });
        }

        [HttpPost]
        public async Task<IActionResult> MarkComplete([FromRoute] int id, ToDo selected)
        {
            var markedAsDone = await service.MarkAsDone(id);
            
            return RedirectToAction("Index", new { ID = id });
        }
        [HttpPost]
        public async Task<IActionResult> DeleteComplete([FromRoute] int id, ToDo selected)
        {
            var Delete = await service.Delete(id);
            return RedirectToAction("Index", new { ID = id });
        }
    }
}
