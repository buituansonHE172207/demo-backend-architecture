using AutoMapper;
using DemoBackendArchitecture.Application.DTOs;
using DemoBackendArchitecture.Domain.Entities;

namespace DemoBackendArchitecture.Application.Mappings;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
}