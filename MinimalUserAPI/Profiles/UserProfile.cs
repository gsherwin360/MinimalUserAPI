using AutoMapper;
using MinimalUserAPI.DTOs;
using MinimalUserAPI.Entities;

namespace MinimalUserAPI.Profiles;

internal class UserProfile : Profile
{
    public UserProfile()
    {
        // Source -> Target
        CreateMap<User, UserReadDto>()
            .ForMember(dest => dest.Fullname, act => act.MapFrom(src => src.FirstName + " " + src.LastName))
            .ForMember(dest => dest.DateUpdated, act => act.MapFrom(src => src.DateUpdated != null ? src.DateUpdated : null));

        CreateMap<UserCreateDto, User>();
        CreateMap<UserUpdateDto, User>()
            .ForMember(dest => dest.DateUpdated, act => act.MapFrom(src => DateTime.Now));
    }
} // End of class