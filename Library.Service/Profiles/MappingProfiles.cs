using AutoMapper;
using Library.Models.Models.Authors;
using Library.Models.Models.Authors.CommandModel;

namespace Library.Service.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Author, AuthorResponse>().ReverseMap();
        CreateMap<AuthorResponse, Author>().ReverseMap();
    }
}
