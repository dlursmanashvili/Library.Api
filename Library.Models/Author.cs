using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models;

public class Author : BaseEntity<Guid>
{
    [Required]
    public string Firstname { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public DateTime DateOfBirth { get; set; }
    public List<BookAuthor> BookAuthors { get; set; } // Добавлено свойство BookAuthors

}
