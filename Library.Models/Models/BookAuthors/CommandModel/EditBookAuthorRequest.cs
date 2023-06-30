namespace Library.Models.Models.BookAuthors.CommandModel;

public class EditBookAuthorRequest
{
    public Guid bookAuthorID { get; set; }
    public Guid BookID { get; set; }
    public Guid AuthorID { get; set; }
    public string AdminMail { get; set; }
    public bool IsDeleted { get; set; }
}
