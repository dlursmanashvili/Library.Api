namespace Library.Models.Models.Books.CommandModel;

public class BookResponse
{
    public BookResponse()
    {
        
    }
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string? Image { get; set; }
    public int? Rating { get; set; }
    public bool InLibrary { get; set; }
    public string? Description { get; set; }
    public DateTime? PublicationDate { get; set; }
    public string? FilePath { get; set; }
}
