using System.ComponentModel.DataAnnotations;

namespace Domain.Responses;

public class Book
{
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Author { get; set; }
    public int PublishYear { get; set; }
    public string Genre { get; set; }
}
