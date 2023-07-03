using System.ComponentModel.DataAnnotations;

namespace Library.Models.Models.Authors.CommandModel;

public class CreateAuthorRequest
{
    public string Firstname { get; set; }
    public string LastName { get; set; }

    public DateTime BirthDate { get; set; }

}

