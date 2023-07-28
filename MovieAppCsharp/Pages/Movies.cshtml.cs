using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieAppCsharp.Data.Models;

namespace MoviesApp.Pages
{
    public class MoviesModel : PageModel
    {
        public List<Movie> Movies { get; set; }

        public void OnGet()
        {
            Movies = new List<Movie>();
            Movies.Add(new Movie
            {
                Id = 1,
                Title = "The Godfather",
                Rate = 9,
                Description =
                    "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son."
            });
            Movies.Add(new Movie()
            {
                Id = 2,
                Title = "The Shawshank Redemption",
                Rate = 9,
                Description =
                    "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency."
            });
            Movies.Add(new Movie
            {
                Id = 3,
                Title = "The Dark Knight",
                Rate = 9,
                Description =
                    "When the menace known as The Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham."
            });
            Movies.Add(new Movie()
            {
                Id = 4,
                Title = "Inception",
                Rate = 8,
                Description =
                    "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O."
            });
        }
    }
}