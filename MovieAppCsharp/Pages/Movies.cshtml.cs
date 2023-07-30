using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieAppCsharp.Data;
using MovieAppCsharp.Data.Models;
using MovieAppCsharp.Services;

namespace MoviesApp.Pages
{
    public class MoviesModel : PageModel
    {
        public List<Movie> Movies { get; set; }

        private IMoviesService _moviesService;

        public MoviesModel(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        public void OnGet()
        {
            Movies = _moviesService.GetAll();
        }
    }
}