namespace Library.Models.Models.BookAuthors.CommandModel;

public class CreateBookAuthorRequest
{
    public Guid BookId { get; set; }
    public Guid AuthorId { get; set; }
    public string AdminMail{ get; set; }
}
