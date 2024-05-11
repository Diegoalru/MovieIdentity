using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieIdentity.Models;
using MovieIdentity.Services;

namespace MovieIdentity.Pages;

public class MovieModel : PageModel
{
    public required SelectList Genres { get; set; } = new(Enum.GetValues<MovieGenre>());
    public List<Movie> Movies { get; set; } = MovieService.GetAll();
    [BindProperty] public Movie NewMovie { get; set; } = new();

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid) return Page();

        MovieService.Add(NewMovie);
        return RedirectToPage();
    }

    public IActionResult OnPostDelete(int id)
    {
        MovieService.Delete(id);
        return RedirectToPage();
    }
}