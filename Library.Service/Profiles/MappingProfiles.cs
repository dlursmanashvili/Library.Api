using AutoMapper;
using Library.Models.Models.Authors;
using Library.Models.Models.Authors.CommandModel;
using Library.Models.Models.Books;
using Library.Models.Models.Books.CommandModel;

namespace Library.Service.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Author, AuthorResponse>().ReverseMap();
        //CreateMap<AuthorResponse, Author>().ReverseMap();
        CreateMap<BookResponse, Book>().ReverseMap();        
    }
}
