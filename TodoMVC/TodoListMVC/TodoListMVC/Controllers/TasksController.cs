using System.Net;
using System.Web.Mvc;
using TodoListMVC.Models;
using TodoListMVC.Services;

namespace TodoListMVC.Controllers
{
    public class TasksController : Controller
    {
        private ITasksService _taskService;

        public TasksController(ITasksService taskService)
        {
            _taskService = taskService;
        }

        // GET: Tasks
        public ActionResult Index()
        {
            return View(_taskService.GetAll());
        }

        // GET: Tasks/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var task = _taskService.GetById(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // GET: Tasks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,Status")] Task task)
        {
            if (ModelState.IsValid)
            {
                _taskService.AddNewTask(task);
                return RedirectToAction("Index");
            }

            return View(task);
        }

        // GET: Tasks/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var task = _taskService.GetById(id);

            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,Status")] Task task)
        {
            if (ModelState.IsValid)
            {
                _taskService.Update(task);
                return RedirectToAction("Index");
            }
            return View(task);
        }

    }
}
