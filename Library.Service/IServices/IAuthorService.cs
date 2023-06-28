using Library.Models;
using Library.Models.Models.Authors;

namespace Library.Service.IServices;

public interface IAuthorService
{
    Task CreateAuthor(string Email, Guid id);
    Task UpdateAuthor(string Email, Guid id);
    Task<CoommandResult> DeleteAuthor(string Email, Guid id);
    Task<Author> GetAuthorById(Guid id);
    Task<IEnumerable<Author>> GetAllAuthors();
}
