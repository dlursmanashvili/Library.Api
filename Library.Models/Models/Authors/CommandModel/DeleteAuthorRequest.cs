namespace Library.Models.Models.Authors.CommandModel;

public class DeleteAuthorRequest
{
    public string AdminEmail { get; set; }
    public Guid id { get; set; }
}
