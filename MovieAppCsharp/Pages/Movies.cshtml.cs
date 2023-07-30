using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieAppCsharp.Data;
using MovieAppCsharp.Data.Models;

namespace MoviesApp.Pages
{
    public class MoviesModel : PageModel
    {
        public List<Movie> Movies { get; set; }
        
        private ApplicationDbContext _context;

        public MoviesModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Movies = _context.Movies.ToList();
        }
    }
}