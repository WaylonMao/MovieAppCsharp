using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieAppCsharp.Data.Models;

namespace MoviesApp.Pages
{
    public class AddMovieModel : PageModel
    {
        // [BindProperty]
        // public string Title { get; set; }
        //
        // [BindProperty]
        // public int Rate { get; set; }
        //
        // [BindProperty]
        // public string Description { get; set; }
        
        [BindProperty]
        public Movie Movie { get; set; }
        
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            string value = $"{Movie.Title}-{Movie.Rate}-{Movie.Description}";
            if (!ModelState.IsValid)
            {
                return Page();
            }
            return Redirect("Movies");
        }
    }
}