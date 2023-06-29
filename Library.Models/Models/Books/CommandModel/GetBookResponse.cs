namespace Library.Models.Models.Books.CommandModel;

public class GetBookResponse
{
    public string Title { get; set; }
    //public string? Image { get; set; }
    public int? Rating { get; set; }
    public bool InLibrary { get; set; }
    public string? Description { get; set; }
    public DateTime? PublicationDate { get; set; }
    public string? FilePath { get; set; }
}
