namespace Library.Models.Models.Books.CommandModel;

public class DeleteBookRequest
{
    public Guid Bookid { get; set; }
    public string AdminEmail { get; set; }
}
