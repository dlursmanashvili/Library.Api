namespace Library.Models.Models.Books.CommandModel;
public class GetAllBooksResponse
{
    public GetAllBooksResponse()
    {  }

    public GetAllBooksResponse(Guid id, string title)
    {
        Id = id;
        Title = title;
    }

    public Guid Id { get; set; }
    public string Title { get; set; }
}
