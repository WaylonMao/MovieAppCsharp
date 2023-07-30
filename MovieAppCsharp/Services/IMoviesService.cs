using MovieAppCsharp.Data.Models;

namespace MovieAppCsharp.Services
{
    public interface IMoviesService
    {
        List<Movie> GetAll();
        Movie? GetById(int id);
        void Add(Movie movie);
    }
}