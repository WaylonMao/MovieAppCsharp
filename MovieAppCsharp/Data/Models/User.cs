namespace MovieAppCsharp.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        // Role can be "Admin" or "User", default is "User"
        public string Role { get; set; } = "User";
    }
}