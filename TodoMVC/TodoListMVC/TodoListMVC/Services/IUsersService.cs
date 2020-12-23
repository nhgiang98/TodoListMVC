using System.Collections.Generic;
using TodoListMVC.Models;

namespace TodoListMVC.Services
{
    public interface IUsersService
    {
        List<User> GetAll();
        User GetById(int id);
        void Update(User user);
        void AddNewUser(User user);
        void DeleteUser(int id);
    }
}
