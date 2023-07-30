using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieAppCsharp.Data;
using MovieAppCsharp.Data.Models;

namespace MoviesApp.Pages
{
    public class AddMovieModel : PageModel
    {
        [BindProperty] public string Title { get; set; }

        [BindProperty] public int Rate { get; set; }

        [BindProperty] public string Description { get; set; }


        private ApplicationDbContext _context;

        public AddMovieModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var movie = new Movie()
            {
                Title = Title,
                Rate = Rate,
                Description = Description
            };
            _context.Movies.Add(movie);
            _context.SaveChanges();
            
            return Redirect("Movies");
        }
    }
}