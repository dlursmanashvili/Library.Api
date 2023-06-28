using Library.Models.Models.BookAuthors;

namespace Library.Models.Models.Books;

public class Book : BaseEntity<Guid>
{
    public string Title { get; set; }
    public string? Image { get; set; }
    public int? Rating { get; set; }
    public bool InLibrary { get; set; }
    public string? Description { get; set; }
    public DateTime? PublicationDate { get; set; }
    public List<BookAuthor> BookAuthors { get; set; }

}