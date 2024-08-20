using AutoMapper;
using DemoBackendArchitecture.Application.DTOs;
using RegisterRequest = DemoBackendArchitecture.API.Models.AuthenticationRequest.RegisterRequest;
using LoginRequest = DemoBackendArchitecture.API.Models.AuthenticationRequest.LoginRequest;

namespace DemoBackendArchitecture.API.Mappings;

public class UserMapping : Profile
{
    public UserMapping()
    {
        CreateMap<LoginRequest, UserDto>().ReverseMap();
        CreateMap<RegisterRequest, UserDto>().ReverseMap();
    }
}