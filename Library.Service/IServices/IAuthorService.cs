using Library.Models;
using Library.Models.Exceptions;
using Library.Models.Models.Authors;
using Library.Models.Models.Authors.CommandModel;
using Library.Models.Models.Books.CommandModel;

namespace Library.Service.IServices;

public interface IAuthorService
{
    /// <summary>
    /// Add new author. 
    /// </summary>
    /// <param name="createAuthorRequest"></param>
    /// <returns><see cref="AuthorResponse/></returns>
    Task<AuthorResponse> CreateAuthor(CreateAuthorRequest createAuthorRequest);

    Task<AuthorResponse> UpdateAuthor(EditAuthorRequest editAuthorRequest);
    Task<bool> DeleteAuthor(DeleteAuthorRequest deleteAuthorRequest);
    Task<IEnumerable<AuthorResponse>?> GetAllAuthors();
    Task<AuthorResponse?> GetAuthorById(Guid id);
    Task<IEnumerable<AuthorResponse>?> SearchAuthor(string FirsName);
}
