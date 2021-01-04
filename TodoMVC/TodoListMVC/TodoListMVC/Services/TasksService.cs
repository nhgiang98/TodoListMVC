using System.Collections.Generic;
using System.Linq;
using TodoListMVC.Models;

namespace TodoListMVC.Services
{
    public class TaskService : ITasksService
    {
        private PGDbContext _context;
        public TaskService(PGDbContext context)
        {
            _context = context;
        }

        public void AddNewTask(Task task)
        {
            var taskvalid = _context.Tasks.FirstOrDefault(x => x.Id == task.Id);
            task.StatusTask = StatusProgress.New.ToString();
            if (taskvalid == null)
            {
                _context.Tasks.Add(task);
                _context.SaveChanges();
            }
        }

        public void Update(Task task)
        {
            var taskInfo = _context.Tasks.FirstOrDefault(x => x.Id == task.Id);

            if (taskInfo != null)
            {
                taskInfo.Description = task.Description;
                taskInfo.StatusTask = task.Status.ToString();
                taskInfo.Status = task.Status;
                _context.SaveChanges();
            }
        }

        public List<Task> GetAll()
        {
            return _context.Tasks.ToList();
        }

        public Task GetById(string id)
        {
            return _context.Tasks.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}