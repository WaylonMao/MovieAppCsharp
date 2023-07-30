using MovieAppCsharp.Data;
using MovieAppCsharp.Data.Models;

namespace MovieAppCsharp.Services
{
    public class MoviesService : IMoviesService
    {
        private ApplicationDbContext _context;

        public MoviesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Movie> GetAll() => _context.Movies.ToList();

        public Movie? GetById(int id) => _context.Movies.FirstOrDefault(m => m.Id == id);

        public void Add(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }
    }
}