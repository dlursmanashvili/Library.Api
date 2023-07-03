namespace Library.Models.Models.Books.CommandModel;
public class CreateBookRequest
{
    public string Title { get; set; }
    public string? FilePath { get; set; }
    public int? Rating { get; set; }
    public string? Description { get; set; }
    public string? iamge{ get; set;}
}
