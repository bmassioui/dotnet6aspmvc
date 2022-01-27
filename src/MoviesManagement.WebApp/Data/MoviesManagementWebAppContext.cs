#nullable disable
using Microsoft.EntityFrameworkCore;
using MoviesManagement.WebApp.Models;

namespace MoviesManagement.WebApp.Data;

public class MoviesManagementWebAppContext : DbContext
{
    public MoviesManagementWebAppContext(DbContextOptions<MoviesManagementWebAppContext> options)
        : base(options)
    {
    }

    public DbSet<Movie> Movie { get; set; }
}
