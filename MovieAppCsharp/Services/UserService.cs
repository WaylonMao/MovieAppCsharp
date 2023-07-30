using MovieAppCsharp.Data;
using MovieAppCsharp.Data.Models;

namespace MovieAppCsharp.Services
{
    public class UserService : IUserService
    {
        private ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public User? GetUserByUsername(string username)
        {
            User? user = _context.Users.FirstOrDefault(u => u != null && u.Username == username);
            return user;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public bool CheckPassword(string username, string password)
        {
            User? user = GetUserByUsername(username);

            if (user != null)
            {
                return user.Password == password;
            }

            return false;
        }
    }
}