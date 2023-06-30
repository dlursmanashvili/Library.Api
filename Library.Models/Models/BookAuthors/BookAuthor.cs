using Library.Models.Models.Authors;
using Library.Models.Models.Books;

namespace Library.Models.Models.BookAuthors;

public class BookAuthor : BaseEntity<Guid>
{
    public Guid BookId { get; set; }
    public Guid AuthorId { get; set; }
}
