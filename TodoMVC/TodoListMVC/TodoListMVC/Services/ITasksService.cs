using System.Collections.Generic;
using TodoListMVC.Models;
namespace TodoListMVC.Services
{
    public interface ITasksService
    {
        List<Task> GetAll();
        Task GetById(string id);
        void Update(Task task);
        void AddNewTask(Task task);
    }
}
