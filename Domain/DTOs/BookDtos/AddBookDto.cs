namespace Domain.DTOs.BookDtos;

public class AddBookDto
{    
    public string Title { get; set; }
    public string Author { get; set; }
    public int PublishYear { get; set; }
    public string Genre { get; set; }
}
