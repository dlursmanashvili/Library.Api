namespace Library.Models;

public class BaseEntity<T>
{
    public T Id { get; set; }
    public bool IsDeleted { get; set; } = false;
}
