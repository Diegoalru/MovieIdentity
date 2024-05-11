using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieIdentity.Pages;

public class AdminsOnlyModel(ILogger<AdminsOnlyModel> logger) : PageModel
{
    public void OnGet()
    {
    }
}