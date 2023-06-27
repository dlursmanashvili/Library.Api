using Library.Models;

namespace Library.Service.IServices;

public interface IAuthorService
{
    Task CreateAuthor(Author author);
    Task UpdateAuthor(Author author);
    Task DeleteAuthor(Author author);
    Task<Author> GetAuthorById(Guid id);
    Task<IEnumerable<Author>> GetAllAuthors();
}
