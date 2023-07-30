using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieAppCsharp.Data;
using MovieAppCsharp.Data.Models;
using MovieAppCsharp.Services;

namespace MoviesApp.Pages
{
    public class MovieModel : PageModel
    {
        public Movie? Movie { get; set; }

        private IMoviesService _moviesService;

        public MovieModel(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        public void OnGet(int id)
        {
            Movie = _moviesService.GetById(id);
        }
    }
}