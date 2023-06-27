namespace Library.Models;

public class Book : BaseEntity<Guid>
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }
    public int? Rating { get; set; }
    public DateTime? PublicationDate { get; set; }
    public bool InLybrary { get; set; }
    public List<BookAuthor> BookAuthors { get; set; }

}