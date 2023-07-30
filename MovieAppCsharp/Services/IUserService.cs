using MovieAppCsharp.Data.Models;

namespace MovieAppCsharp.Services
{
    public interface IUserService
    {
        User? GetUserByUsername(string username);

        void AddUser(User user);

        bool CheckPassword(string username, string password);
    }
}