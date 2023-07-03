namespace Library.Models.Models.Authors.CommandModel;

public class AuthorResponse
{
    public AuthorResponse()
    {
        
    }
    public Guid Id { get; set; }
    public string Firstname { get; set; }
    public string LastName { get; set; }
}
