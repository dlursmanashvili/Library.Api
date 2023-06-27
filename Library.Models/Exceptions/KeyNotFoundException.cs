namespace Library.Models.Exceptions;
public class KeyNotFoundException : Exception
{
    public KeyNotFoundException(string msg) : base(msg) { }
}
