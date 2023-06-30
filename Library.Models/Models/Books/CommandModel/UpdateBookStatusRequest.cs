namespace Library.Models.Models.Books.CommandModel;

public class UpdateBookStatusRequest
{
  public   Guid? BookId { get; set; }
    public bool BookStatus { get; set; }
}
