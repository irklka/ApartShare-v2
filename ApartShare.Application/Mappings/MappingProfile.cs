using ApartShare.Application.Models.Users;
using ApartShare.Core.Entities;

using AutoMapper;

namespace ApartShare.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserRegisterDto, User>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Fullname));
    }
}
