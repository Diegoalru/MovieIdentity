using System.ComponentModel.DataAnnotations;

namespace MovieIdentity.Models;

public class Movie
{
    public int Id { get; set; }

    [Required] public string? Name { get; set; }

    public MovieGenre Genre { get; set; }

    [Range(1900, 2024)] public int Year { get; set; }
}

public enum MovieGenre
{
    Action,
    Comedy,
    Drama,
    Horror,
    Thriller,
    Romance
}