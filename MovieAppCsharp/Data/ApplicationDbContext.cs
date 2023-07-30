using Microsoft.EntityFrameworkCore;
using MovieAppCsharp.Data.Models;

namespace MovieAppCsharp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<User?> Users { get; set; }
    }
}