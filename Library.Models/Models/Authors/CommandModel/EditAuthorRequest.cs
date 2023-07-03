namespace Library.Models.Models.Authors.CommandModel;

public class EditAuthorRequest
{
    public Guid AuthorID { get; set; }
    public string Firstname { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public bool IsDeleted { get; set; }
}
