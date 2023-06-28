using System.ComponentModel.DataAnnotations;
using Library.Models.Models.BookAuthors;

namespace Library.Models.Models.Authors;

public class Author : BaseEntity<Guid>
{
    [Required]
    public string Firstname { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public List<BookAuthor> BookAuthors { get; set; }

}
