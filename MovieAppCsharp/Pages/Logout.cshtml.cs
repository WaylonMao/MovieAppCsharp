using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieAppCsharp.Pages;

public class LogoutModel : PageModel
{
    public async Task OnPostAsync()
    {
        // Sign out the user
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        
        // Redirect to the home page
        Response.Redirect("/");
    }
}