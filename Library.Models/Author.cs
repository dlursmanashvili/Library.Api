using System.ComponentModel.DataAnnotations;

namespace Library.Models;

public class Author : BaseEntity<Guid>
{
    [Required]
    public string Firstname { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public List<BookAuthor> BookAuthors { get; set; } 

}
