using Microsoft.EntityFrameworkCore;
using MoviesManagement.WebApp.Data;
using MoviesManagement.WebApp.Models;

namespace MoviesManagement.WebApp.Extensions;

public static class ServiceProviderExtensions
{
    /// <summary>
    /// Run database migrations
    /// Insert preconfigured data for development purposes 
    /// </summary>
    /// <param name="serviceProvider"></param>
    /// <param name="isDevelopment"></param>
    public static void MigrateDatabase(IServiceProvider serviceProvider, bool isDevelopment)
    {
        using var context = new MoviesManagementWebAppContext(serviceProvider.GetRequiredService<DbContextOptions<MoviesManagementWebAppContext>>());

        // Execute missing Migrations
        context.Database.Migrate();

        if (!isDevelopment) return;

        // Look for any movies.
        if (context.Movie.Any())
        {
            return;   // DB has been seeded
        }

        context.Movie.AddRange(GetPreconfiguredMovies());

        context.SaveChanges();
    }

    /// <summary>
    /// Preconfigured data for Development Environment
    /// </summary>
    /// <returns></returns>
    private static IEnumerable<Movie> GetPreconfiguredMovies()
    {
        return new List<Movie>
        {
            new Movie
            {
                Title = "When Harry Met Sally",
                ReleaseDate = DateTime.Parse("1989-2-12"),
                Genre = "Romantic Comedy",
                Price = 7.99M
            },

            new Movie
            {
                Title = "Ghostbusters ",
                ReleaseDate = DateTime.Parse("1984-3-13"),
                Genre = "Comedy",
                Price = 8.99M
            },

            new Movie
            {
                Title = "Ghostbusters 2",
                ReleaseDate = DateTime.Parse("1986-2-23"),
                Genre = "Comedy",
                Price = 9.99M
            },

            new Movie
            {
                Title = "Rio Bravo",
                ReleaseDate = DateTime.Parse("1959-4-15"),
                Genre = "Western",
                Price = 3.99M
            }
        };
    }
}
