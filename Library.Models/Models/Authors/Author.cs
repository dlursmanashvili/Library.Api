using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Library.Models.Models.BookAuthors;

namespace Library.Models.Models.Authors;

public class Author : BaseEntity<Guid>
{
    [Required]
    public string Firstname { get; set; }
    [Required]
    public string LastName { get; set; }

    public DateTime BirthDate { get; set; }

    [NotMapped]
    public List<BookAuthor> BookAuthors { get; set; }

}
