using Library.Infrastructure.Repositories.Interfaces;
using Library.Infrastructure.Repositories.Repository;
using Library.Service.FileManagement;
using Library.Service.IServices;
using Library.Service.Services;

namespace Library.Api;

public static class DI
{
    public static void DependecyResolver(IServiceCollection services)
    {
        services.AddScoped<IAuthorService, AuthorService>();
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IBookAuthorService, BookAuthorService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IAuthentification, Authentification>();
        services.AddScoped<IFileService, FileService>();

        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IBookAuthorRepository, BookAuthorRepository>();
    }
}
