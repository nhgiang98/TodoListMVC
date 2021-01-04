using System.Collections.Generic;
using System.Linq;
using TodoListMVC.Common;
using TodoListMVC.Models;

namespace TodoListMVC.Services
{
    public class UsersService : IUsersService
    {
        private PGDbContext _context;

        public UsersService(PGDbContext context)
        {
            _context = context;
        }
        public void AddNewUser(User user)
        {
            var uservalid = _context.Users.FirstOrDefault(us => us.Username == user.Username);

            if (uservalid == null)
            {
                user.Password = EncryptHelper.Encrypt(user.Password);
                _context.Users.Add(user);
                _context.SaveChanges();
            }
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(int id)
        {
            return _context.Users.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Update(User user)
        {
            var userInfo = _context.Users.FirstOrDefault(us => us.Username == user.Username);

            if (userInfo != null)
            {
                userInfo.Address = user.Address;
                userInfo.PhoneNumber = user.PhoneNumber;
                userInfo.Email = user.Email;
                userInfo.Name = user.Name;
                _context.SaveChanges();
            }
        }
    }
}