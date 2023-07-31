using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieAppCsharp.Data.Models;
using MovieAppCsharp.Services;

namespace MovieAppCsharp.Pages;

public class LoginModel : PageModel
{
    private IUserService _userService;

    public LoginModel(IUserService userService)
    {
        _userService = userService;
    }

    [BindProperty] public string Username { get; set; }
    [BindProperty] public string Password { get; set; }

    [TempData] public string ErrorMessage { get; set; }

    public void OnGet()
    {
        if (TempData.TryGetValue("RegisteredUsername", out object registeredUsername))
        {
            Username = registeredUsername.ToString();
        }
    }

    public async Task<IActionResult> OnPostAsync()
    {
        // Check if model is valid
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // Check if user exists
        User? user = _userService.GetUserByUsername(Username);
        if (user == null)
        {
            ErrorMessage = "User does not exist!";
            return Page();
        }

        // Check if passwords match
        if (!_userService.CheckPassword(Username, Password))
        {
            ErrorMessage = "Password is incorrect!";
            return Page();
        }

        // Create the ClaimsIdentity based on the claims
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, Username),
            new Claim(ClaimTypes.Role, user.Role)
        };
        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        
        // Create the ClaimsPrincipal
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        
        // Sign in the user
        await HttpContext.SignInAsync(claimsPrincipal);

        // Redirect to another page if successful
        return RedirectToPage("Index");
    }
}