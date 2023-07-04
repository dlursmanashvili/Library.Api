namespace Library.Models.Models.BookAuthors.CommandModel;

public class UpdateBookAuthorRequest
{
    public Guid Id { get; set; }
    public Guid BookId { get; set; }
    public Guid AuthorId { get; set; }
}
