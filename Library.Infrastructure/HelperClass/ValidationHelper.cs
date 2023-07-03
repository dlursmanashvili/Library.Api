using Library.Models.Models.Authors;
using System.Reflection;

namespace Library.Infrastructure.HelperClass;

public static class ValidationHelper
{
  
    public static void AuthorValidation(Author? author)
    {

        if (author == null) throw new Exception($"author not found.");
    }


    public static string GetNullParameterName(object obj)
    {
        var objType = obj.GetType();
        IList<PropertyInfo> properties = new List<PropertyInfo>(objType.GetProperties());
        //var properties = obj.GetType().GetProperties();
        foreach (var property in properties)
        {
            var value = property.GetValue(obj);
            if (value == null || (value.GetType() == typeof(string) && value.ToString().Length == 0))
            {
                throw new Exception($"{property.Name} is null or empty");
            }
        }
        return string.Empty;
    }
}
