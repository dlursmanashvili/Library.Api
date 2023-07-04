using AutoMapper;
using Library.Models.Models.Authors;
using Library.Models.Models.Authors.CommandModel;
using Library.Models.Models.BookAuthors;
using Library.Models.Models.BookAuthors.CommandModel;
using Library.Models.Models.Books;
using Library.Models.Models.Books.CommandModel;

namespace Library.Service.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Author, AuthorResponse>().ReverseMap();
        CreateMap<BookResponse, Book>().ReverseMap();        
        CreateMap<BookAuthor,BookAuthorResponse>().ReverseMap(); 
        
    }
}
