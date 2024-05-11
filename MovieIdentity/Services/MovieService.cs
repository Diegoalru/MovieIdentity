using MovieIdentity.Models;

namespace MovieIdentity.Services;

public static class MovieService
{
    private static int _nextId = 4;

    static MovieService()
    {
        Movies = new List<Movie>
        {
            new() { Id = 1, Name = "The Shaw shank Redemption", Genre = MovieGenre.Drama, Year = 1994 },
            new() { Id = 2, Name = "The Godfather", Genre = MovieGenre.Drama, Year = 1972 },
            new() { Id = 3, Name = "The Dark Knight", Genre = MovieGenre.Action, Year = 2008 }
        };
    }

    private static List<Movie> Movies { get; }

    public static List<Movie> GetAll()
    {
        return Movies;
    }

    public static Movie? GetById(int id)
    {
        return Movies.FirstOrDefault(p => p.Id == id);
    }

    public static void Add(Movie movie)
    {
        movie.Id = _nextId++;
        Movies.Add(movie);
    }

    public static void Update(Movie movie)
    {
        var existingMovie = Movies.FirstOrDefault(p => p.Id == movie.Id);

        if (existingMovie is null) return;

        existingMovie.Name = movie.Name;
        existingMovie.Genre = movie.Genre;
        existingMovie.Year = movie.Year;
    }

    public static void Delete(int id)
    {
        var existingMovie = Movies.FirstOrDefault(p => p.Id == id);
        if (existingMovie is not null) Movies.Remove(existingMovie);
    }
}