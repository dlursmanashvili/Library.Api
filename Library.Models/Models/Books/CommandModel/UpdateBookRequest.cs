namespace Library.Models.Models.Books.CommandModel;

public class UpdateBookRequest
{
    public Guid Bookid { get; set; }
    public string Title { get; set; }
    public string? FilePath { get; set; }
    public int? Rating { get; set; }
    public string? Description { get; set; }
    public bool InLibrary { get; set; }
    public string AdminEmail { get; set; }
}
