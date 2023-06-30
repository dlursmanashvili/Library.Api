namespace Library.Models.Models.BookAuthors.CommandModel;

public class DeleteBookAuthorRequest
{
    public Guid bookAuthorID { get; set; }
    public Guid BookId { get; set; }
    public Guid AuthorId { get; set; }
    public string AdminMail { get; set; }
}
