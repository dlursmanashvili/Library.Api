using System.ComponentModel.DataAnnotations;

namespace Library.Models;

public class Author : BaseEntity<Guid>
{
    [Required]
    public string Firstname { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public DateTime DateOfBirth { get; set; }
    public List<BookAuthor> BookAuthors { get; set; } 

}
