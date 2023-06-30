namespace Library.Models.Models.BookAuthors.CommandModel;

public class GetBookAuthorResponse
{
    public Guid BookAuthorID { get; set; }
    public Guid BookId { get; set; }
    public Guid AuthorId { get; set; }
    //public string? BookTitle { get; set; }
    ////public string? Image { get; set; }
    //public int? BookRating { get; set; }
    //public bool? BookInLibrary { get; set; }
    //public string? BookDescription { get; set; }
    //public DateTime? BookPublicationDate { get; set; }
    //public string? AuthorFirstname { get; set; }
    //public string? AuthorLastName { get; set; }
    //public DateTime? BirthDate { get; set; }
}
