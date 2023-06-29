using Library.Models;
using Library.Models.Models.Authors;
using Library.Models.Models.Authors.CommandModel;

namespace Library.Service.IServices;

public interface IAuthorService
{
    Task<CoommandResult> CreateAuthor(CreateAuthorRequest createAuthorRequest);
    Task<CoommandResult> UpdateAuthor(EditAuthorRequest editAuthorRequest);
    Task<CoommandResult> DeleteAuthor(DeleteAuthorRequest deleteAuthorRequest);
    Task<IEnumerable<GetAuthorResponse>?> GetAllAuthors();
    Task<GetAuthorResponse?> GetAuthorById(Guid id);
}
