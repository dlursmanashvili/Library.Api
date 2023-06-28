using Library.Models.Models.Authors;
using Library.Models.Models.Employee;

namespace Library.Infrastructure.HelperClass;

public static class ValidationHelper
{
    public static void UserValidation(Employee? user, string Email, bool AdminPermission)
    {
        if (user == null) throw new Exception($"ServiceEmail {Email} already exists.");

        if (user != null && AdminPermission == true && user.IsAdministrator != true) throw new Exception($"The user {Email} is not administrator.");
    }

    public static void AuthorValidation(Author? author)
    {
        if (author == null) throw new Exception($"author not found.");    
    }
}
