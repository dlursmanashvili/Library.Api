using Library.Infrastructure.Interfaces;
using Library.Infrastructure.Repositorie;
using Library.Service.IServices;
using Library.Service.Services;

namespace Library;

public static class DI
{
    public static void DependecyResolver(IServiceCollection services)
    {
        services.AddScoped<IAuthorService, AuthorService>();
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IBookAuthorService, BookAuthorService>(); 
        services.AddScoped<IEmployeeService, EmployeeService>(); 

        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IBookAuthorRepository, BookAuthorRepository>();
    }
}
