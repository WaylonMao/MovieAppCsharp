using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieAppCsharp.Data.Models;
using MovieAppCsharp.Services;

namespace MovieAppCsharp.Pages
{
    public class RegisterModel : PageModel
    {
        private IUserService _userService;
        
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public string ConfirmPassword { get; set; }
        [TempData]
        public string ErrorMessage { get; set; }
        
        public RegisterModel(IUserService userService)
        {
            _userService = userService;
        }
        
        public void OnGet()
        {
        }
        
        public IActionResult OnPost()
        {
            // Check if model is valid
            if(!ModelState.IsValid)
            {
                return Page();
            }
            
            // Check if passwords match
            if (Password != ConfirmPassword)
            {
                ErrorMessage = "Passwords do not match!";
                return Page();
            }
            
            User user = new User
            {
                Username = Username,
                Password = Password
            };
            
            // Add user to database
            _userService.AddUser(user);
            
            TempData["RegisteredUsername"] = Username;

            // Redirect to another page if successful
            return RedirectToPage("Login"); 
        }
    }
}
