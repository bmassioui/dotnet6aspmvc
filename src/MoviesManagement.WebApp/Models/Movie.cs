using System.ComponentModel.DataAnnotations;

namespace MoviesManagement.WebApp.Models;

public class Movie
{
    [Key]
    public Guid Id { get; set; }
    public string? Title { get; set; }

    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
    public string? Genre { get; set; }
    public decimal Price { get; set; }
}
